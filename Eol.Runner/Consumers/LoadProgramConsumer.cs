using Eol.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Eol.Runner.Consumers
{
    public class LoadProgramConsumer : IConsumer<LoadProgram>
    {
        public Task Consume(ConsumeContext<LoadProgram> context)
        {
            return Task.CompletedTask;
        }
    }
}
