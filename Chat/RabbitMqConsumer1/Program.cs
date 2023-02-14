using Chat.Domain.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

Console.WriteLine("Enter username");
var username = Console.ReadLine();
Console.WriteLine("Enter chatroom");
var chatRoom = Console.ReadLine();

var factory = new ConnectionFactory() { HostName = "localhost" };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    ResponseMessage? msg = JsonSerializer.Deserialize<ResponseMessage>(message);
    Console.WriteLine($"{msg.Author} : {msg.Text}");
};

channel.BasicConsume(queue: username, autoAck: true, consumer: consumer);
Console.WriteLine($"{username} - consuming");
Console.ReadKey();


//channel.ExchangeDeclare(exchange: chatRoom, ExchangeType.Direct);
////channel.ExchangeDeclare(exchange: "user", ExchangeType.Direct);

//channel.QueueDeclare(queue: username);

//channel.QueueBind(queue: username, exchange: chatRoom, routingKey: "bahur");

//channel.QueueBind(queue: username, exchange: "user",
//    routingKey: username);
