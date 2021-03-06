﻿using System;
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
    public class IT5_UserInterfaceToCookCtrl_Display_Light
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
            _powerTube = new PowerTube(_output);
            _timer = new Timer();
            _display = new Display(_output);
            _powerbutton = new Button();
            _timerButton = new Button();
            _startCancelButton = new Button();
            _door = new Door();
            _light = new Light(_output);
            cookController = new CookController(_timer, _display, _powerTube);
            _userInterface = new UserInterface(_powerbutton,_timerButton,_startCancelButton,_door,_display,_light,cookController);
            cookController.UI = _userInterface;




        }



        [Test]
        public void OnPowerPressed()
        {
           _powerbutton.Press();
           _output.Received().OutputLine($"Display shows: {50} W");
        }
       
       [Test]
        public void OnTimePressed()
        {
            _powerbutton.Press();
            _timerButton.Press();
            _output.Received().OutputLine($"Display shows: {1:D2}:{0:D2}");
        }
    }
}
