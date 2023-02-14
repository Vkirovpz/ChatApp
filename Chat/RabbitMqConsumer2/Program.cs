//using Chat.Domain.Models;
//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Net.Http.Json;
//using System.Text;
//using System.Text.Json;

////Console.WriteLine("Enter username");
////var username = Console.ReadLine();
////Console.WriteLine("Enter chatroom");
////var chatRoomKey = Console.ReadLine();


////var factory = new ConnectionFactory() { HostName = "localhost" };

////using var connection = factory.CreateConnection();
////using var channel = connection.CreateModel();

////channel.ExchangeDeclare(exchange: "messages", ExchangeType.Direct);

////channel.QueueDeclare(queue: username);

////channel.QueueBind(queue: username, exchange: "messages",
////    routingKey: chatRoomKey);

////var consumer = new EventingBasicConsumer(channel);
////consumer.Received += (model, ea) =>
////{
////    var body = ea.Body.ToArray();
////    var message = Encoding.UTF8.GetString(body);
////    ResponseMessage msg = JsonSerializer.Deserialize<ResponseMessage>(message);
////    Console.WriteLine($"{msg.Author} : {msg.Text}");
////};
////channel.BasicConsume(queue: username, autoAck: true, consumer: consumer);
////Console.WriteLine($"{username} - consuming");
////Console.ReadKey();

//class Program
//{
//    static HttpClient client = new HttpClient();

//    static async Task<ConnectedUserResponse> ConnectUserAsync(string username)
//    {
//        var request = new UserRequest(username);
//        var json = JsonSerializer.Serialize(request);
//        var content = new StringContent(json, Encoding.UTF8, "application/json");
//        var response = await client.PostAsync("/connectUser", content);
//        response.EnsureSuccessStatusCode();
//        var connectedUser = await response.Content.ReadFromJsonAsync<ConnectedUserResponse>();
//        return connectedUser;
//    }

//    public async Task<DisconnectedUserResponse> LeaveRoomAsync(string username)
//    {
//        var request = new UserRequest(username);
//        var json = JsonSerializer.Serialize(request);
//        var content = new StringContent(json, Encoding.UTF8, "application/json");
//        var response = await client.PostAsync("/leaveRoom", content);
//        response.EnsureSuccessStatusCode();
//        var disconnectedUser = await response.Content.ReadFromJsonAsync<DisconnectedUserResponse>();
//        return disconnectedUser;
//    }

//    public async Task<CreatedRoomResponse> CreateRoomAsync(string username, string roomName)
//    {
//        var request = new CreateRoomRequest(username, roomName);
//        var json = JsonSerializer.Serialize(request);
//        var content = new StringContent(json, Encoding.UTF8, "application/json");
//        var response = await client.PostAsync("/createRoom", content);
//        response.EnsureSuccessStatusCode();
//        var createdRoom = await response.Content.ReadFromJsonAsync<CreatedRoomResponse>();
//        return createdRoom;
//    }

//    public record CreateRoomRequest(string username, string roomName);

//    public record CreatedRoomResponse(bool IsCreated, string RoomName, string Reason = default);
//    public record UserRequest(string Username);
//    public record ConnectedUserResponse(bool IsConnected, string Username, string Reason = null);
//    public record DisconnectedUserResponse(bool IsDisconnected, string Username);

//    private static void Main(string[] args)
//    {
//        RunAsync().GetAwaiter().GetResult();
//    }

//    static async Task RunAsync()
//    {
//        // Update port # in the following line.
//        client.BaseAddress = new Uri("https://localhost:7106/api/Users");
//        client.DefaultRequestHeaders.Accept.Clear();
//        client.DefaultRequestHeaders.Accept.Add(
//            new MediaTypeWithQualityHeaderValue("application/json"));

//        try
//        {
//            Console.WriteLine("Enter username");
//            var username = Console.ReadLine();
//            // Create a new product

//            var connectedUser = await ConnectUserAsync(username);
//            Console.WriteLine($"{connectedUser.IsConnected}");

//            //// Get the product
//            //product = await GetProductAsync(url.PathAndQuery);
//            //ShowProduct(product);

//            //// Update the product
//            //Console.WriteLine("Updating price...");
//            //product.Price = 80;
//            //await UpdateProductAsync(product);

//            //// Get the updated product
//            //product = await GetProductAsync(url.PathAndQuery);
//            //ShowProduct(product);

//            //// Delete the product
//            //var statusCode = await DeleteProductAsync(product.Id);
//            //Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

//        }
//        catch (Exception e)
//        {
//            Console.WriteLine(e.Message);
//        }

//        Console.ReadLine();
//    }

//}
