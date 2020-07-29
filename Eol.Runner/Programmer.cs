using Eol.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Eol.Runner
{
    public class Programmer
    {
        private readonly byte[] program;
        private readonly Eater eater;

        public Programmer(Eater eater, byte[] program)
        {
            this.eater = eater;
            this.program = program;
        }

        public void LoadAndRun()
        {
            Console.WriteLine();
            StopClock();
            SetToWrite();
            LoadProgram();
            SetToRead();
            Reset();
            StartClock();
            Console.WriteLine();
        }

        private void StartClock()
        {
            Console.WriteLine("Stopping Clock");

        }

        private void Reset()
        {
            Console.WriteLine("Resetting");

        }

        private void SetToRead()
        {
            

            eater.EnterProgramMode();
        }

        private void LoadProgram()
        {
            Console.WriteLine("Loading program");
            for (byte i = 0; i < program.Length; i++)
            {
                eater.SetByte(program[i], i);
            }
        }

        private void SetToWrite()
        {

            eater.EnterRunMode();
        }

        private void StopClock()
        {
            Console.WriteLine("Starting Clock");
        }
    }
}
