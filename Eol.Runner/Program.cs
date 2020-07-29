using System;
using System.Linq;
using Eol.Messages;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Eol.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Eater eater = null;
            if (args.Count(a => a.ToLower() == "testing") == 1)
            {
                Console.WriteLine("Entering testing mode");
                eater = new Eater(new FakeGpio());
            }
            else
            {
                Console.WriteLine("Entering real mode");
                eater = new Eater(new Gpio());
            }

            //var bus = Bus.Factory.CreateUsingAzureServiceBus(sbc =>
            //{
            //    sbc.Host("Endpoint=sb://eateronlineservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=QTRhb/VlxmgJ94QTsxnO83yP/+PLErNtdwb+ro1yuWE=");
            //    sbc.ReceiveEndpoint("input-queue", ep =>
            //    {
            //        ep.Handler<LoadProgram>(context =>
            //        {
            //            return Console.Out.WriteLineAsync($"Received");
            //        });
            //    });
            //});

            //bus.Start();

            //Console.WriteLine("Programming the Eater");
            //eater.SetByte(0b1110_0000, 0b1000);
            //Console.WriteLine("Proceed?");
            //Console.ReadLine();
            //eater.SetByte(0b1111_0000, 0b0001);
            //Console.WriteLine("Done");
            //Console.WriteLine("Proceed?");
            //Console.ReadLine();
            //while (true)
            //{
            //    eater.SetByte(0b0000_0000, 0b0000);
            //    eater.SetByte(0b0000_0001, 0b0001);
            //    eater.SetByte(0b0000_0010, 0b0010);
            //    eater.SetByte(0b0000_0100, 0b0011);
            //    eater.SetByte(0b0000_1000, 0b0100);
            //    eater.SetByte(0b0001_0000, 0b0101);
            //    eater.SetByte(0b0010_0000, 0b0110);
            //    eater.SetByte(0b0100_0000, 0b1000);
            //    eater.SetByte(0b1000_0000, 0b1001);
            var prog = new byte[16];
            prog[0b0000] = 0b0000_0000;
            prog[0b0001] = 0b0000_0001;
            prog[0b0010] = 0b0000_0010;
            prog[0b0011] = 0b0000_0100;
            prog[0b0100] = 0b0000_1000;
            prog[0b0101] = 0b0001_0000;
            prog[0b0110] = 0b0010_0000;
            prog[0b1000] = 0b0100_0000;
            prog[0b1001] = 0b1000_0000;

            var cont = true;
            cont = Console.ReadKey().Key.ToString().ToLower() == "y";
            while (cont)
            {
                var programmer = new Programmer(eater, prog);

                cont = Console.ReadKey().Key.ToString().ToLower() == "y";
            }
        }
    }
}
