using Chat.Domain;
using Chat.Domain.Models;
using RabbitMQ.WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {   
        services.AddHostedService<Worker>();
        services.AddTransient<ChatServerAppService>();
        services.AddSingleton<Server>();
        services.AddTransient<IMessageWriter, TextWriterMessageWriter>();
        services.AddSingleton(Console.Out);
    })
    .Build();

await host.RunAsync();
