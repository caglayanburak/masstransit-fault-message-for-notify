using System;
using MassTransit;

namespace PublisherSample
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("test");
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
                      {
                          var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                          {
                              h.Username("guest");
                              h.Password("guest");
                          });
                          cfg.ReceiveEndpoint(host, "trendyol_fault_test", e =>
                                            {
                                                EndpointConvention.Map<Order>(e.InputAddress);
                                            });
                      });

            busControl.Start();
            busControl.Publish<Test>(new Test() { Name = "test" }).Wait();
            System.Console.WriteLine("gönderdim");
            busControl.Stop();

            Console.ReadLine();
        }
    }
}
