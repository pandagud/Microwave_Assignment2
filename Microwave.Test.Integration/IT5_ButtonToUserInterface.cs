using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Microwave.Test.Integration
{
    [TestFixture]
    public class IT5_ButtonToUserInterface
    {
        private IOutput _output;
        private ILight _light;
        private IDoor _driverDoor;
        private UserInterface _userInterface;
        private IPowerTube _powerTube;
        private ITimer _timer;
        private IDisplay _display;
        private ICookController cookController;
        private IButton _powerbutton;
        private IButton _timerButton;
        private IButton _startCancelButton;
      

        [SetUp]
        public void Setup()
        {
            _driverDoor = Substitute.For<IDoor>();
            _light = Substitute.For<ILight>();
            _output = Substitute.For<IOutput>();
            _powerTube = Substitute.For<IPowerTube>();
            _timer = Substitute.For<ITimer>();
            _display = Substitute.For<IDisplay>();
            _powerbutton = new Button();
            _timerButton = new Button();
            _startCancelButton = new Button();
            _light = Substitute.For<ILight>();
            cookController = Substitute.For<ICookController>();
            _userInterface = new UserInterface(_powerbutton, _timerButton, _startCancelButton, _driverDoor, _display, _light, cookController);
            
        }

        [Test]
        public void OnPowerButtonPressed()
        {
            _userInterface.OnPowerPressed(_powerbutton, System.EventArgs.Empty);
            _display.Received().ShowPower(50);
            // Laver ikke for den anden state da det er den samme metode som bliver anvendt. Tror det er argument nok. ellers er det nemt nok lige at lave en testcase for det.
        }
        [Test]
        public void OnTimerButtonPressed()
        {
            _userInterface.OnPowerPressed(_powerbutton, System.EventArgs.Empty);
            _userInterface.OnTimePressed(_timerButton, System.EventArgs.Empty);
            _display.Received().ShowTime(1,0);

        }
        [Test]
        public void OnStartCancelButtonPressed_StateSetPower()
        {
            _userInterface.OnPowerPressed(_powerbutton, System.EventArgs.Empty);
            _userInterface.OnStartCancelPressed(_startCancelButton, System.EventArgs.Empty);
            _light.Received().TurnOff();

        }
        [Test]
        public void OnStartCancelButtonPressed_StateSetTime()
        {
            _userInterface.OnPowerPressed(_powerbutton, System.EventArgs.Empty);
            _userInterface.OnTimePressed(_timerButton, System.EventArgs.Empty);
            _userInterface.OnStartCancelPressed(_startCancelButton, System.EventArgs.Empty);
            _light.Received().TurnOn();

        }
        [Test]
        public void OnStartCancelButtonPressed_StateCOOKING_IntegrationToCookController()
        {
            _userInterface.OnPowerPressed(_powerbutton, System.EventArgs.Empty);
            _userInterface.OnTimePressed(_timerButton, System.EventArgs.Empty);
            _userInterface.OnStartCancelPressed(_startCancelButton, System.EventArgs.Empty);

            cookController.Received().StartCooking(50, 60);


        }
        [Test]
        public void OnStartCancelButtonPressed_StateCOOKING_IntegrationToLight()
        {
            _userInterface.OnPowerPressed(_powerbutton, System.EventArgs.Empty);
            
            _userInterface.OnStartCancelPressed(_startCancelButton, System.EventArgs.Empty);

           
            _light.Received().TurnOff();
           

        }
        [Test]
        public void OnStartCancelButtonPressed_StateCOOKING_IntegrationToDisplay()
        {
            _userInterface.OnPowerPressed(_powerbutton, System.EventArgs.Empty);
            _userInterface.OnStartCancelPressed(_startCancelButton, System.EventArgs.Empty);

            _display.Received().Clear();

        }
    }
}
