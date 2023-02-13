using Chat.Domain.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

Console.WriteLine("Enter username");
var username = Console.ReadLine();
Console.WriteLine("Enter chatroom");
var chatRoomKey = Console.ReadLine();


var factory = new ConnectionFactory() { HostName = "localhost" };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "messages", ExchangeType.Direct);

channel.QueueDeclare(queue: username);

//var queueName = channel.QueueDeclare().QueueName;

channel.QueueBind(queue: username, exchange: "messages",
    routingKey: chatRoomKey);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    ResponseMessage msg = JsonSerializer.Deserialize<ResponseMessage>(message);
    Console.WriteLine($"{msg.Author} : {msg.Text}");
};
channel.BasicConsume(queue: username, autoAck: true, consumer: consumer);
Console.WriteLine("Consumer2 - consuming");
Console.ReadKey();


public class ChatAppHttpClient
{
    private readonly HttpClient httpClient;

    public ChatAppHttpClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ConnectedUserResponse> ConnectUserAsync(string username)
    {
        var request = new UserRequest(username);
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("/connectUser", content);
        response.EnsureSuccessStatusCode();
        var connectedUser = await response.Content.ReadFromJsonAsync<ConnectedUserResponse>();
        return connectedUser;
    }

    public async Task<DisconnectedUserResponse> LeaveRoomAsync(string username)
    {
        var request = new UserRequest(username);
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("/leaveRoom", content);
        response.EnsureSuccessStatusCode();
        var disconnectedUser = await response.Content.ReadFromJsonAsync<DisconnectedUserResponse>();
        return disconnectedUser;
    }

    public async Task<CreatedRoomResponse> CreateRoomAsync(string username, string roomName)
    {
        var request = new CreateRoomRequest(username, roomName);
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("/createRoom", content);
        response.EnsureSuccessStatusCode();
        var createdRoom = await response.Content.ReadFromJsonAsync<CreatedRoomResponse>();
        return createdRoom;
    }

    public record CreateRoomRequest(string username, string roomName);

    public record CreatedRoomResponse(bool IsCreated, string RoomName, string Reason = default);
    public record UserRequest(string Username);
    public record ConnectedUserResponse(bool IsConnected, string Username, string Reason = null);
    public record DisconnectedUserResponse(bool IsDisconnected, string Username);
   
}