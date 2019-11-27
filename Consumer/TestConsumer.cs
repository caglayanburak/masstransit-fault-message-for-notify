using MassTransit;
using System.Threading.Tasks;
using PublisherSample;
using System;

namespace MassTransitFaultSample
{
    public class TestConsumer : IConsumer<Test>
    {
        public Task Consume(ConsumeContext<Test> context)
        {
            System.Console.WriteLine("consume context");
            throw new Exception("test");
            return Task.CompletedTask;
        }
    }
}