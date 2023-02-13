using Chat.Domain.Models;

namespace RabbitMqProducer.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        public void SendMessage(Message msg);
    }
}

