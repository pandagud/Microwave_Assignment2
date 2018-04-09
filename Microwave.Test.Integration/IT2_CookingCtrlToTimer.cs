using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Timer = MicrowaveOvenClasses.Boundary.Timer;

namespace Microwave.Test.Integration
{
    [TestFixture]
    public class IT2_CookingCtrlToDisplay_PowerTube
    {
        private IOutput _output;
        private IPowerTube _powerTube;
        private ITimer _timer;
        private IDisplay _display;
        private ICookController _uut;

        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            _powerTube = new PowerTube(_output);
            _timer = new Timer();
            _display = new Display(_output);
   
            _uut = new CookController(_timer,_display,_powerTube);
            

        }
        
        [TestCase(20, 60)]
        public void CookcontrollerTimerTestNotStoppedCooking(int power, int time)
        {
            _uut.StartCooking(power,time);
            Thread.Sleep(59000);
            _output.DidNotReceive().OutputLine($"Powertube turned off");
        }
        [TestCase(20, 1)]
        public void CookcontrollerTimerTestStoppedCooking(int power, int time)
        {
            _uut.StartCooking(power, time);
            Thread.Sleep(61000);
            _output.Received().OutputLine($"PowerTube turned off");
        }



    }
}
