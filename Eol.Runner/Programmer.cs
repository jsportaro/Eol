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
            StopClock();
            SetToWrite();
            LoadProgram();
            SetToRead();
            Reset();
            StartClock();
        }

        private void StartClock()
        {
        }

        private void Reset()
        {
        }

        private void SetToRead()
        {
            eater.EnterProgramMode();
        }

        private void LoadProgram()
        {
            for (byte i = 0; i < 16; i++)
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
        }
    }
}
