using MassTransit;
using System.Threading.Tasks;
using System;
using MassTransit.Util;
using PublisherSample;

namespace MassTransitFaultSample
{
    public class TestFaultConsumer : IConsumer<Fault<Test>>
    {
        public Task Consume(ConsumeContext<Fault<Test>> context)
        {
            System.Console.WriteLine("Consume fault");
            return Task.CompletedTask;
        }
    }

    
}