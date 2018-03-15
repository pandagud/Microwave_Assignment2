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
    public class IT4_CookingCtrl
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

        [TestCase(20,10)]
        public void CookcontrollerStartCooking(int power, int time)
        {
            _uut.StartCooking(power,time);
            _output.Received().OutputLine($"PowerTube works with {power} %");
            Assert.AreEqual(time, _timer.TimeRemaining);
            
           
            
        }

        [TestCase(20, 10)]
        public void CookcontrollerStopCooking(int power, int time)
        {
            _uut.StartCooking(power,time);
            _uut.Stop();
            _output.Received().OutputLine($"PowerTube turned off");
            // Hvordan tester vi stopfuction i Timer classen. 
            

        }

       


    }
}
