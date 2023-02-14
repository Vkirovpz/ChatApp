using Chat.Domain.Models;
using Chat.Domain;
using RabbitMqProducer.RabbitMQ;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<ChatServerAppService>();
builder.Services.AddSingleton<Server>();
builder.Services.AddTransient<IMessageWriter, TextWriterMessageWriter>();
builder.Services.AddTransient<IMessagePublisher, RabbitMqChatMessagePublisher>();
builder.Services.AddSingleton(provider =>
{
    var factory = new ConnectionFactory { HostName = "localhost" };
    IConnection connection = factory.CreateConnection();
    return connection;
});

builder.Services.AddSingleton(provider=>
{
    var connection = provider.GetRequiredService<IConnection>();
    IModel channel = connection.CreateModel();
    return channel;
});

builder.Services.AddSingleton(Console.Out);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
