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
    }
}
