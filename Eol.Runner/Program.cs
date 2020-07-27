using System;

namespace Eol.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var eater = new Eater(new Gpio());

            while (true)
            {
                eater.SetByte(0b0000_0000, 0b0000);
                eater.SetByte(0b0000_0001, 0b0001);
                eater.SetByte(0b0000_0010, 0b0010);
                eater.SetByte(0b0000_0100, 0b0011);
                eater.SetByte(0b0000_1000, 0b0100);
                eater.SetByte(0b0001_0000, 0b0101);
                eater.SetByte(0b0010_0000, 0b0110);
                eater.SetByte(0b0100_0000, 0b1000);
                eater.SetByte(0b1000_0000, 0b1001);
            }
        }
    }
}
