using Chat.Domain.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System.Data.Common;
using System.Text;

public class Program
{
    private static HubConnection _connection;
    private static async Task Main(string[] args)
    {
        _connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7021/chatHub")
            .Build();

        await ConnectAsync();

        Console.WriteLine("Enter your username");
        var username = Console.ReadLine();
        var userIsConnected = await _connection.InvokeAsync<bool>("ConnectUser", username);

        if (userIsConnected)
        {
            while (true)
            {
                OptionsMenu();
                var cmd = Console.ReadLine();
                if (cmd == "1")
                {
                    Console.WriteLine("Enter name to create new chat room");
                    var newRoomName = Console.ReadLine();
                    var roomResponse = await _connection.InvokeAsync<CreatedRoom>("CreateRoom", username, newRoomName);
                    Console.WriteLine(roomResponse.IsCreated);
                    Console.WriteLine(roomResponse.RoomName);
                    Console.WriteLine(roomResponse.Reason);
                }
                else if (cmd == "2")
                {
                    var roomName = Console.ReadLine();
                    var connected = await _connection.InvokeAsync<ConnectedUserToChatRoom>("JoinRoom", username, roomName);
                    
                    if (connected.IsConnected)
                    {
                        var message = Console.ReadLine();
                        while (!string.Equals(message, "qw!", StringComparison.OrdinalIgnoreCase))
                        {
                            await _connection.InvokeAsync("SendMessage", username, message);
                            message = Console.ReadLine();
                        }
                    }
                }
                else if (cmd == "3")
                {

                }
                else if (cmd == "exit")
                    break;
            }
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

    private static async void ConnectUser(string user)
    {
        try
        {
            await _connection.InvokeAsync("ConnectUser", user);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e}");
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

    private static async void JoinRoom(string user, string roomName)
    {
        try
        {
            await _connection.InvokeAsync("JoinRoom", user, roomName);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e}");
        }
    }

    private static async void LeaveRoom(string user, string roomName)
    {
        try
        {
            await _connection.InvokeAsync("LeaveRoom", user, roomName);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e}");
        }
    }

    private static async void CreateRoom(string user, string roomName)
    {
        try
        {
            await _connection.InvokeAsync("CreateRoom", user, roomName);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e}");
        }
    }

    static void OptionsMenu()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Menu:");
        sb.AppendLine("Press 1 to create new room");
        sb.AppendLine("Press 2 to join room");
        sb.AppendLine("Press 3 to show existing rooms");
        Console.WriteLine(sb.ToString());
    }
}

