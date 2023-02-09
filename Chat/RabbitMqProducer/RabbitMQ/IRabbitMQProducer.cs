namespace RabbitMqProducer.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        public void SendMessage<T>(T msg);
        public void SendMessageDirect<T>(T msg);
    }
}

