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
            _powerTube = Substitute.For<IPowerTube>();
            _timer = new Timer();
            _display = Substitute.For<IDisplay>();
   
            _uut = new CookController(_timer,_display,_powerTube);
            

        }

        [TestCase(20,10)]
        public void CookcontrollerStartCooking(int power, int time)
        {
            _uut.StartCooking(power,time);
            _powerTube.Received().TurnOn(power);
           
            
        }

        [TestCase(20, 10)]
        public void CookcontrollerStopCooking(int power, int time)
        {
            _uut.StartCooking(power,time);
            _uut.Stop();
            _powerTube.Received().TurnOff();
            

        }


    }
}
