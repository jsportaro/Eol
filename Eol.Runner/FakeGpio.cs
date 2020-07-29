using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Text;

namespace Eol.Runner
{
    public class FakeGpio : IGpio
    {
        public void OpenPin(int bit0, PinMode output)
        {
        }

        public void Write(int bit0, PinValue high)
        {
        }
    }
}
