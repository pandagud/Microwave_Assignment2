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
    public class IT7_UserInterfaceToCookCtrl_Display_Light
    {
        private IOutput _output;
        private ILight _light;
        private IPowerTube _powerTube;
        private ITimer _timer;
        private IDisplay _display;
        private CookController cookController;
        private UserInterface _userInterface;
        private IButton _powerbutton;
        private IButton _timerButton;
        private IButton _startCancelButton;
        private IDoor _door;

        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            _powerTube = Substitute.For<IPowerTube>();
            _timer = Substitute.For<ITimer>();
            _display = new Display(_output);
            _powerbutton = Substitute.For<IButton>();
            _timerButton = Substitute.For<IButton>();
            _startCancelButton = Substitute.For<IButton>();
            _door = Substitute.For<IDoor>();
            _light = Substitute.For<ILight>();
            cookController = new CookController(_timer, _display, _powerTube);
            _userInterface = new UserInterface(_powerbutton,_timerButton,_startCancelButton,_door,_display,_light,cookController);
            cookController.UI = _userInterface;




        }



        [Test]
        public void OnPowerPressed()
        {
           _userInterface.OnPowerPressed(_powerbutton, System.EventArgs.Empty);
           _output.Received().OutputLine($"Display shows: {50} W");
        }
       
       [Test]
        public void OnTimePressed()
        {
            _userInterface.OnPowerPressed(_powerbutton, System.EventArgs.Empty);
            _userInterface.OnTimePressed(_timerButton, System.EventArgs.Empty);
            _output.Received().OutputLine($"Display shows: {1:D2}:{0:D2}");
        }
    }
}
