using MassTransit;

namespace RabbitMqMassTransitExample;

public class TestMessageConsumer : IConsumer<TestMessage>
{
    public async Task Consume(ConsumeContext<TestMessage> context)
    {
        var message = context.Message;
        await Task.Run(() =>
        {
            Console.WriteLine($"Received message: {message.Text}");
        });
    }
}