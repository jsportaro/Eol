using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Text;

namespace Eol.Runner
{
    public class Gpio : IGpio, IDisposable
    {
        private readonly GpioController gpioController = new GpioController();

        public void Dispose()
        {
            gpioController.Dispose();
        }

        public void OpenPin(int pin, PinMode mode)
        {
            gpioController.OpenPin(pin, mode);
        }

        public void Write(int pin, PinValue value)
        {
            gpioController.Write(pin, value);
        }
    }
}
