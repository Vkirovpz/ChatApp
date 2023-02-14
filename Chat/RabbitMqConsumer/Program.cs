using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using RabbitMQ.Client.Events;
using Chat.Domain.Models;
using RabbitMQ.Client;
using System.Net.Http;

class Program
{
    static HttpClient client = new HttpClient();

    static async Task<ConnectedUserResponse> ConnectUserAsync(string username)
    {
        var json = JsonSerializer.Serialize(username);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/connectUser", content);
        response.EnsureSuccessStatusCode();
        var connectedUser = await response.Content.ReadFromJsonAsync<ConnectedUserResponse>();
        return connectedUser;
    }

    static async Task<DisconnectedUserResponse> DisconnectUserAsync(string username)
    {
        var json = JsonSerializer.Serialize(username);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/leaveRoom", content);
        response.EnsureSuccessStatusCode();
        var disconnectedUser = await response.Content.ReadFromJsonAsync<DisconnectedUserResponse>();
        return disconnectedUser;
    }

    static async Task<CreatedRoomResponse> CreateRoomAsync(string username, string roomName)
    {
        var request = new CreateRoomRequest(username, roomName);
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/createRoom", content);
        response.EnsureSuccessStatusCode();
        var createdRoom = await response.Content.ReadFromJsonAsync<CreatedRoomResponse>();
        return createdRoom;
    }

    static async Task<ConnectedUserResponse> JoinRoomAsync(string username, string roomName)
    {
        var request = new JoinRoomRequest(username, roomName);
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/joinRoom", content);
        response.EnsureSuccessStatusCode();
        var connectedUserToChatRoom = await response.Content.ReadFromJsonAsync<ConnectedUserResponse>();
        return connectedUserToChatRoom;
    }

    static async Task<string> SendMessageAsync(string username, string message)
    {
        var request = new SendMessageRequest(username, message);
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/sendMessage", content);
        response.EnsureSuccessStatusCode();
        var emptyResponse = await response.Content.ReadAsStringAsync();
        return emptyResponse;
    }

    static async Task<List<string>> GetAllRoomNamesAsync()
    {
        var response = await client.GetAsync("/getAllRooms");
        response.EnsureSuccessStatusCode();
        var resp = await response.Content.ReadAsStringAsync();
        List<string> names = JsonSerializer.Deserialize<List<string>>(resp);
        return names;

    }

    public record CreateRoomRequest(string username, string roomName);
    public record CreatedRoomResponse(bool IsCreated, string RoomName, string Reason = default);
    public record UserRequest(string Username);
    public record ConnectedUserResponse(bool IsConnected, string Username, string Reason = null);
    public record DisconnectedUserResponse(bool IsDisconnected, string Username);
    public record JoinRoomRequest(string username, string roomName);

    public record SendMessageRequest(string username, string message);


    private static void Main(string[] args)
    {
        RunAsync().GetAwaiter().GetResult();
    }

    static async Task RunAsync()
    {
        client.BaseAddress = new Uri("https://localhost:7106");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        try
        {
            Console.WriteLine("Enter username");
            var username = Console.ReadLine();
            var connectedUser = await ConnectUserAsync(username);

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
                        var createdRoom = await CreateRoomAsync(username, roomName);
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
                        var connectedUserToChatRoom = await JoinRoomAsync(username, joinRoomName);
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
                                    var disconnectUser = await DisconnectUserAsync(username);
                                    if (disconnectUser.IsDisconnected)
                                    {
                                        Console.WriteLine($"{username} disconnected");
                                        Console.Clear();
                                    }
                                    break;
                                }
                                await SendMessageAsync(username, msg);
                            }
                        }

                    }
                    else if (cmd == "3")
                    {
                        Console.Clear();
                        var rooms = await GetAllRoomNamesAsync();
                   
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

