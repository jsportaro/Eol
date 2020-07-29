using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Security.Principal;
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
        private const int Addr0 = 15;
        private const int Addr1 = 18;
        private const int Addr2 = 23;
        private const int Addr3 = 24;

        private const int SetWrite = 13;
        private const int SetRead = 19;
        
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

            gpio.OpenPin(Addr0, PinMode.Output);
            gpio.OpenPin(Addr1, PinMode.Output);
            gpio.OpenPin(Addr2, PinMode.Output);
            gpio.OpenPin(Addr3, PinMode.Output);

            gpio.OpenPin(SetRead, PinMode.Output);
            gpio.OpenPin(SetWrite, PinMode.Output);
        }

        public void SetByte(byte b, byte address)
        {
            Console.WriteLine($"Setting value {b} at {address}");

            gpio.Write(Bit0, IsBitSet(b, 0) ? PinValue.High : PinValue.Low);
            gpio.Write(Bit1, IsBitSet(b, 1) ? PinValue.High : PinValue.Low);
            gpio.Write(Bit2, IsBitSet(b, 2) ? PinValue.High : PinValue.Low);
            gpio.Write(Bit3, IsBitSet(b, 3) ? PinValue.High : PinValue.Low);
            gpio.Write(Bit4, IsBitSet(b, 4) ? PinValue.High : PinValue.Low);
            gpio.Write(Bit5, IsBitSet(b, 5) ? PinValue.High : PinValue.Low);
            gpio.Write(Bit6, IsBitSet(b, 6) ? PinValue.High : PinValue.Low);
            gpio.Write(Bit7, IsBitSet(b, 7) ? PinValue.High : PinValue.Low);

            gpio.Write(Addr0, IsBitSet(address, 0) ? PinValue.High : PinValue.Low);
            gpio.Write(Addr1, IsBitSet(address, 1) ? PinValue.High : PinValue.Low);
            gpio.Write(Addr2, IsBitSet(address, 2) ? PinValue.High : PinValue.Low);
            gpio.Write(Addr3, IsBitSet(address, 3) ? PinValue.High : PinValue.Low);

            
            gpio.Write(Set, PinValue.High);

            Thread.Sleep(1000);
            gpio.Write(Set, PinValue.Low);
        }

        public void EnterProgramMode()
        {
            gpio.Write(SetWrite, PinValue.Low);
            gpio.Write(SetRead, PinValue.High);
        }

        public void EnterRunMode()
        {
            gpio.Write(SetWrite, PinValue.High);
            gpio.Write(SetRead, PinValue.Low);
        }

        bool IsBitSet(byte b, int pos)
        {
            return (b & (1 << pos)) != 0;
        }

    }
}
