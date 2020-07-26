using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Text;
using System.Threading;

namespace Eol.Runner
{
    public class Eater
    {
        private const int Clock = 17;
        private const int Bit0 = 27;
        private const int Bit1 = 22;
        private const int Bit2 = 10;
        private const int Bit3 = 9;
        private const int Bit4 = 11;
        private const int Bit5 = 0;
        private const int Bit6 = 5;
        private const int Bit7 = 6;
        private const int Set = 26;
        private const int SetWrite = 13;
        private const int SetRun = 19;
        
        private readonly IGpio gpio;


        public Eater(IGpio gpio)
        {
            this.gpio = gpio;

            SetPins();
        }

        private void SetPins()
        {
            gpio.OpenPin(Clock, PinMode.Output);

            gpio.OpenPin(Bit0, PinMode.Output);
            gpio.OpenPin(Bit1, PinMode.Output);
            gpio.OpenPin(Bit2, PinMode.Output);
            gpio.OpenPin(Bit3, PinMode.Output);
            gpio.OpenPin(Bit4, PinMode.Output);
            gpio.OpenPin(Bit5, PinMode.Output);
            gpio.OpenPin(Bit6, PinMode.Output);
            gpio.OpenPin(Bit7, PinMode.Output);
            gpio.OpenPin(Set, PinMode.Output);
        }

        public void SetByte(byte b, short address)
        {
            gpio.Write(Bit0, PinValue.High);
            gpio.Write(Bit1, PinValue.High);
            gpio.Write(Bit2, PinValue.High);
            gpio.Write(Bit3, PinValue.High);
            gpio.Write(Bit4, PinValue.High);
            gpio.Write(Bit5, PinValue.High);
            gpio.Write(Bit6, PinValue.High);
            gpio.Write(Bit7, PinValue.High);

            gpio.Write(Set, PinValue.High);
            Thread.Sleep(1000);
            gpio.Write(Set, PinValue.Low);
        }

        public void SetMode(EaterMode mode)
        {
            throw new NotImplementedException();
        }
    }
}
