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
    [TestFixture]
    public class IT3_PowerTubeToDisplay
    {
        private IOutput _output;
        private IPowerTube _uut;

        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            _uut = new PowerTube(_output);
            
        }

        #region PowerTube




        [TestCase(200)]
        public void PowerTubeToDisplayTurnOnArgumentOutOfRagenException(int power)
        {

            Assert.Throws<ArgumentOutOfRangeException>(() => _uut.TurnOn(power));



        }
        [TestCase(20)]
        public void PowerTubeToDisplayTurnOnApplicationException(int power)
        {
            _uut.TurnOn(power);

            Assert.Throws<ApplicationException>(() => _uut.TurnOn(power));

        }
        [TestCase(20)]
        public void PowerTubeToDisplayTurnOn(int power)
        {
            _uut.TurnOn(power);

            _output.Received().OutputLine($"PowerTube works with {power} %");

        }

        #endregion

    }
}
