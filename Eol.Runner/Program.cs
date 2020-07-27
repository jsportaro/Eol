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
                eater.SetByte(0b0000_0000, 1);
                eater.SetByte(0b0000_0001, 1);
                eater.SetByte(0b0000_0010, 1);
                eater.SetByte(0b0000_0100, 1);
                eater.SetByte(0b0000_1000, 1);
                eater.SetByte(0b0001_0000, 1);
                eater.SetByte(0b0010_0000, 1);
                eater.SetByte(0b0100_0000, 1);
                eater.SetByte(0b1000_0000, 1);
            }
        }
    }
}
