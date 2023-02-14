using Chat.Domain;
using Chat.Domain.Models;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMqProducer.RabbitMQ
{
    public class RabbitMqChatMessagePublisher : IMessagePublisher
    {
        private readonly IModel model;

        public RabbitMqChatMessagePublisher(IModel model)
        {
            this.model = model;
        }

        public Task PublishAsync(Message message)
        {
            model.ExchangeDeclare(message.Room, type: ExchangeType.Direct);

            var json = System.Text.Json.JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            model.BasicPublish(exchange: message.Room, "all", null, body);
            return Task.CompletedTask;
        }

        public Task SubscribeAsync(User user, ChatRoom room)
        {
            model.ExchangeDeclare(exchange: room.Name, ExchangeType.Direct);

            model.QueueDeclare(queue: user.Username, true, false);

            model.QueueBind(queue: user.Username, exchange: room.Name, routingKey: "all");
            model.QueueBind(queue: user.Username, exchange: room.Name, routingKey: user.Username);

            return Task.CompletedTask;
        }

        public Task UnsubscribeAsync(User user)
        {
            model.QueueDelete(queue: user.Username);
            return Task.CompletedTask;
        }
    }
}
