using Microsoft.AspNetCore.SignalR.Client;

public class Program
{
    private static HubConnection _connection;
    private static async Task Main(string[] args)
    {
        _connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7021/chatHub")
            .Build();

        _connection.Closed += async (error) =>
        {
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await _connection.StartAsync();
        };

        await ConnectAsync();
        Console.WriteLine("Enter your username");
        var user = Console.ReadLine();

        bool stop = false;
        var message = Console.ReadLine();
        while (!string.Equals(message, "qw!", StringComparison.CurrentCultureIgnoreCase))
        {
            Send(user, message);
            message = Console.ReadLine();
        }
    }

    private static async Task ConnectAsync()
    {
        _connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            Console.WriteLine($"{user}: {message}");
        });
        try
        {
            await _connection.StartAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: {0}", e);
        }
    }

    private static async void Send(string user, string msg)
    {
        try
        {
            await _connection.InvokeAsync("SendMessage", user, msg);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e}");
        }
    }
}

