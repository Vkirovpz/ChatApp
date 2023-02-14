using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using RabbitMQ.Client.Events;
using Chat.Domain.Models;
using RabbitMQ.Client;

class Program
{
    private static async Task Main(string[] args)
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://localhost:7106");
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var client = new ChatHttpClient(httpClient);
        await RunAsync(client);
    }

    static async Task RunAsync(ChatHttpClient client)
    {
        try
        {
            Console.WriteLine("Enter username");
            var username = Console.ReadLine();
            var connectedUser = await client.ConnectUserAsync(username);

            if (connectedUser.IsConnected)
            {
                Console.WriteLine($"User {connectedUser.Username} connected succesfully to server");
                while (true)
                {
                    OptionsMenu();
                    var cmd = Console.ReadLine();
                    if (cmd == "1")
                    {
                        Console.WriteLine("Enter room name");
                        var roomName = Console.ReadLine();
                        var createdRoom = await client.CreateRoomAsync(username, roomName);
                        if (createdRoom.IsCreated)
                        {
                            Console.WriteLine($"Room {createdRoom.RoomName} created succesfully");
                            Console.Clear();
                        }
                    }
                    else if (cmd == "2")
                    {
                        Console.WriteLine("Enter chat room name to join it");
                        var joinRoomName = Console.ReadLine();
                        var connectedUserToChatRoom = await client.JoinRoomAsync(username, joinRoomName);
                        if (connectedUserToChatRoom.IsConnected)
                        {
                            var factory = new ConnectionFactory() { HostName = "localhost" };
                            using var connection = factory.CreateConnection();
                            using var channel = connection.CreateModel();

                            var consumer = new EventingBasicConsumer(channel);
                            consumer.Received += (model, ea) =>
                            {
                                var body = ea.Body.ToArray();
                                var message = Encoding.UTF8.GetString(body);
                                ResponseMessage? msg = JsonSerializer.Deserialize<ResponseMessage>(message);
                                Console.WriteLine($"{msg.Author} : {msg.Text}");
                            };

                            channel.BasicConsume(queue: username, autoAck: true, consumer: consumer);
                            Console.Clear();

                            Console.WriteLine($"{username} - joined chat room");
                            Console.WriteLine("Enter message");
                            while (true)
                            {
                                var msg = Console.ReadLine();
                                if (string.Equals(msg, "qw!", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    var disconnectUser = await client.DisconnectUserAsync(username);
                                    if (disconnectUser.IsDisconnected)
                                    {
                                        Console.WriteLine($"{username} disconnected");
                                        Console.Clear();
                                    }
                                    break;
                                }
                                await client.SendMessageAsync(username, msg);
                            }
                        }

                    }   
                    else if (cmd == "3")
                    {
                        Console.Clear();
                        var rooms = await client.GetAllRoomNamesAsync();

                        foreach (var room in rooms)
                        {
                            Console.WriteLine($"{room}");
                        }
                    }

                }
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.ReadLine();
        void OptionsMenu()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Menu:");
            sb.AppendLine("Press 1 to create new room");
            sb.AppendLine("Press 2 to join room");
            sb.AppendLine("Press 3 to show existing rooms");
            Console.WriteLine(sb.ToString());
        }
    }
}

