using MassTransit;
using Microsoft.Extensions.Hosting;

namespace RabbitMqMassTransitExample;

public class MessagePublisherService : BackgroundService
{
    private readonly IBus _bus;

    public MessagePublisherService(IBus bus)
    {
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _bus.Publish(new TestMessage { Text = "Hello, RabbitMQ!" });
            await Task.Delay(10000, stoppingToken);
        }
    }
}