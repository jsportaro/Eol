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
                eater.SetByte(0b1010_1010, 1);
            }
        }
    }
}
