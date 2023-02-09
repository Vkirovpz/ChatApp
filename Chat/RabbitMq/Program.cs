using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        //Read Input 
        string username = Console.ReadLine();
        // Send
        Send("users", username);
    }
    public IConnection GetConnection(string hostName, string userName, string password)
    {
        ConnectionFactory connectionFactory = new ConnectionFactory();
        connectionFactory.HostName = hostName;
        connectionFactory.UserName = userName;
        connectionFactory.Password = password;
        return connectionFactory.CreateConnection();
    }

    public static void Send(string queue, string data)
    {
        using (IConnection connection = new ConnectionFactory().CreateConnection())
        {
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue, true, false, false, null);
                channel.BasicPublish(string.Empty, queue, null, Encoding.UTF8.GetBytes(data));
            }
        }
    }

    public static void Receive(string queue)
    {
        using (IConnection connection = new ConnectionFactory().CreateConnection())
        {
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue, false, false, false, null);
                var consumer = new EventingBasicConsumer(channel);
                BasicGetResult result = channel.BasicGet(queue, true);
                if (result != null)
                {
                    string data = Encoding.UTF8.GetString(result.Body.Span);
                    Console.WriteLine(data);
                }
            }
        }
    }
}