using Chat.Domain.Models;

namespace RabbitMqProducer.RabbitMQ
{
    public class RabbitMQMessageWriter : IMessageWriter
    {
        private readonly IRabbitMQProducer producer;

        public RabbitMQMessageWriter(IRabbitMQProducer producer)
        {
            this.producer = producer;
        }

        public Task WriteMessageAsync(Message message)
        {
            producer.SendMessage(message);
            return Task.CompletedTask;
        }
    }
}
 