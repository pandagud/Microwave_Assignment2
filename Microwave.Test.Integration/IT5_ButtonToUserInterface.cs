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
    [TestFixture()]
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
        private IDoor _door;

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
        public void OnPowerPressed()
        {
            _userInterface.OnPowerPressed(_powerbutton, System.EventArgs.Empty);

        }
    }
}
