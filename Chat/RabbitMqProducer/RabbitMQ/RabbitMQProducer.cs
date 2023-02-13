using Chat.Domain.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMqProducer.RabbitMQ
{
    public class RabbitMQProducer : IRabbitMQProducer
    { 
        public void SendMessage(Message msg)
        {
            var room = msg.Room;
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare("messages", type: ExchangeType.Direct);

            var json = JsonConvert.SerializeObject(msg);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "messages", room, null, body);
            Console.WriteLine($" [x] Sent Direct message {body}");
        }
    }
}
