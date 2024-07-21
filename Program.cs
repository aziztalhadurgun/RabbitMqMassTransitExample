using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMqMassTransitExample;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((context, services) =>
{
    // MassTransit yapılandırması
    services.AddMassTransit(x =>
    {
        x.AddConsumer<TestMessageConsumer>();

        x.UsingRabbitMq((ctx, cfg) =>
        {
            cfg.Host("rabbitmq://localhost");
            cfg.ReceiveEndpoint("test-queue", e =>
            {
                e.ConfigureConsumer<TestMessageConsumer>(ctx);
            });
        });
    });

    services.AddHostedService<MessagePublisherService>();
    
});

var app = builder.Build();
app.Run();