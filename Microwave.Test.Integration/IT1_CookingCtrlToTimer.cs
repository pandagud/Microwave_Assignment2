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
    public class IT1_CookingCtrlToTimer
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
            _powerTube = Substitute.For<IPowerTube>();//new PowerTube(_output);
            _timer = new Timer();
            _display = Substitute.For<IDisplay>();  //new Display(_output);

            _uut = new CookController(_timer,_display,_powerTube);
            

        }
        
        [TestCase(20, 60)] //sæt 60 ind
        public void CookcontrollerTimerTestNotStoppedCooking(int power, int time)
        {
            _uut.StartCooking(power,time);
            Thread.Sleep(59000);
            _powerTube.DidNotReceive().TurnOff();
        }
        [TestCase(20, 60)]
        public void CookcontrollerTimerTestStoppedCooking(int power, int time)
        {
            _uut.StartCooking(power, time);
            Thread.Sleep(61000);
            _powerTube.Received().TurnOff();
        }



    }
}
