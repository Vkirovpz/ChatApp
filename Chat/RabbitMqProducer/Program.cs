using Chat.Domain.Models;
using Chat.Domain;
using RabbitMqProducer.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<ChatServerAppService>();
builder.Services.AddSingleton<Server>();
builder.Services.AddTransient<IMessageWriter, TextWriterMessageWriter>();
builder.Services.AddSingleton(Console.Out);
builder.Services.AddScoped<IRabbitMQProducer, RabbitMQProducer>();
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
