using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMqProducer.RabbitMQ
{
    public class RabbitMQProducer : IRabbitMQProducer
    { 

        public void SendMessage<T>(T msg)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare("messagesExchange", type: ExchangeType.Fanout);

            var json = JsonConvert.SerializeObject(msg);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "messagesExchange", "", null, body);
            Console.WriteLine($" [x] Sent Fanout message {body}");

        }

        public void SendMessageDirect<T>(T msg)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare("user", type: ExchangeType.Direct);

            var json = JsonConvert.SerializeObject(msg);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "messagesExchange", "user", null, body);
            Console.WriteLine($" [x] Sent Direct message {body}");
        }
    }
}
