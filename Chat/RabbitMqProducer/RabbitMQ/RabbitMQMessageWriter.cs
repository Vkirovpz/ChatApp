using Chat.Domain.Models;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMqProducer.RabbitMQ
{
    public class RabbitMQMessageWriter : IMessageWriter
    {
        private readonly IRabbitMQProducer producer;

        public RabbitMQMessageWriter(IRabbitMQProducer producer)
        {
            this.producer = producer;
        }

        public async Task WriteMessageAsync(Message message)
        {
           producer.SendMessage(message);
        }
    }
}
