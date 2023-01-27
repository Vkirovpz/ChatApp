using Grpc.Core;
using Grpc.Net.Client;
using GrpcStreaming;

internal class Program
{
     static async Task Main(string[] args)
    {
        AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

        Console.WriteLine("Enter Username :");
        var username = Console.ReadLine();

        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Name = username
        };

        var channel = GrpcChannel.ForAddress("http://localhost:5000", new GrpcChannelOptions { Credentials = ChannelCredentials.Insecure });
        var client = new UserService.UserServiceClient(channel);

        var joinUserReply = await client.JoinUserChatAsync(new JoinUserRequest
        {
            User = user
        });

        using (var streaming = client.SendMessageToChatRoom(new Metadata { new Metadata.Entry("UserName", user.Name) }))
        {
            var response = Task.Run(async () =>
            {
                while (await streaming.ResponseStream.MoveNext())
                {
                    Console.WriteLine($"{streaming.ResponseStream.Current.UserName}: {streaming.ResponseStream.Current.Message}");

                }
            });

            await streaming.RequestStream.WriteAsync(new ChatMessage
            {
                UserId = user.Id,
                Message = "",
                RoomId = joinUserReply.RoomId,
                UserName = user.Name
            });

            Console.WriteLine($"Joined the chat as {user.Name}");

            var message = Console.ReadLine();


            while (!string.Equals(message, "qw!", StringComparison.OrdinalIgnoreCase))
            {
                await streaming.RequestStream.WriteAsync(new ChatMessage
                {
                    UserId = user.Id,
                    UserName = user.Name,
                    Message = message,
                    RoomId = joinUserReply.RoomId
                });
                message = Console.ReadLine();

            }
            await streaming.RequestStream.CompleteAsync();
        }
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
