using System;
using MassTransit;
using PublisherSample;

namespace MassTransitFaultSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
             var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint(host, "trendyol_fault_test", e =>
                {
                    e.PrefetchCount = 1;
                    e.Consumer<TestConsumer>();
                    e.Consumer<TestFaultConsumer>();
                });
            });
            busControl.Start();
            
            Console.ReadLine();
        }
    }
}
