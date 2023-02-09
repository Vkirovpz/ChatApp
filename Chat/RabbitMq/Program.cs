using RabbitMq;
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
        string result = Send(username);
        if (result == "True")
        {

        }
        else
        {

        }
    }

    public static string Send(string username)
    {
        var rpcClient = new RpcClient();
        return rpcClient.CallAsync(username).GetAwaiter().GetResult();
    }
}