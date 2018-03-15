using MicrowaveOvenClasses.Interfaces;

namespace MicrowaveOvenClasses.Boundary
{
    public class Light : ILight
    {
        private IOutput myOutput;
        private bool IsOn = false;
        
        public Light(IOutput output)
        {
            myOutput = output;
        }

        public void TurnOn()
        {
            if (!IsOn)
            {
                myOutput.OutputLine("Light is turned on");
                IsOn = true;
            }
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                myOutput.OutputLine("Light is turned off");
                IsOn = false;
            }
        }

    }
}