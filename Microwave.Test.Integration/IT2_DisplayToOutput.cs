using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Microwave.Test.Integration
{
    [TestFixture()]
    class IT2_DisplayToOutput
    {
        private IOutput _output;
        private IDisplay _uut;
     

        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();

            _uut = new Display(_output);
            
        }

        [TestCase(1)]
        [TestCase(5)]
        public void DisplayPower(int power)
        {
            _uut.ShowPower(power);
            _output.Received().OutputLine($"Display shows: {power} W");
        }


        [TestCase(5, 2)]
        [TestCase(10, 5)]
        public void DisplayTimer(int minutes, int seconds)
        {
            _uut.ShowTime(minutes, seconds);
            _output.Received().OutputLine($"Display shows: {minutes:D2}:{seconds:D2}");

        }
        [Test]
        public void DisplayClear()
        {
            _uut.Clear();
            _output.Received().OutputLine($"Display cleared");

        }
    }
}
