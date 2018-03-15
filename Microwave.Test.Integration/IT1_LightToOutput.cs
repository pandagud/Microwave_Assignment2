using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Interfaces;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NSubstitute;

namespace Microwave.Test.Integration
{
    [TestFixture]
    public class IT1_LightToOutput
    {
        private IOutput _output;
        private ILight _uut;

        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            _uut = new Light(_output);
        }

        [Test]
        public void LightOn_Output()
        {
            _uut.TurnOn();
           _output.Received().OutputLine("Light is turned on");
        
        }
        [Test]
        public void LightOff_Output()
        {
            _uut.TurnOff();
            _output.Received().OutputLine("Light is turned off");

        }

    }
}
