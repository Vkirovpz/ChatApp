using Chat.Grpc.Client.Protos;
using Grpc.Core;
using Grpc.Net.Client;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;


//Console.WriteLine("Enter server address");
//var address = Console.ReadLine();

var channel = GrpcChannel.ForAddress("https://localhost:5000", new GrpcChannelOptions { Credentials = ChannelCredentials.SecureSsl });
var client = new ChatServer.ChatServerClient(channel);

Console.WriteLine("Enter your username");
var username = Console.ReadLine();

var userConnectResponse = await client.ConnectUserAsync(new ConnectUserRequest
{
    Username = username
});

Console.WriteLine(userConnectResponse.Success);
Console.WriteLine(userConnectResponse.Reason);
Console.Clear();

if (userConnectResponse.Success == true)
{
    OptionsMenu();
    var cmd = Console.ReadLine();
    while (true)
    {
        if (cmd == "1")
        {
            Console.WriteLine("Enter name to create new chat room");
            var newRoomName = Console.ReadLine();

            var createChatRoomResponse = await client.CreateChatRoomAsync(new CreateChatRoomRequest
            {
                RoomName = newRoomName,
                Username = username

            });

            Console.WriteLine(createChatRoomResponse.Success);
            Console.WriteLine(createChatRoomResponse.Reason);
            Console.Clear();
        }
        else if (cmd == "2") 
        {
            Console.WriteLine("Enter chat room name to join it");
            var joinRoomName = Console.ReadLine();
            var cts = new CancellationTokenSource();
            var joinChatRoomResponse = client.JoinChatRoom(new JoinChatRoomRequest
            {
                RoomName = joinRoomName,
                Username = username
            }, cancellationToken: cts.Token);

            var reading = Task.Run(async () =>
            {
                Console.WriteLine("Starting background task to receive messages");
                try
                {
                    while (await joinChatRoomResponse.ResponseStream.MoveNext())
                    {
                        Console.WriteLine($"{joinChatRoomResponse.ResponseStream.Current.Author} : {joinChatRoomResponse.ResponseStream.Current.Text}");
                    }
                }
                catch (RpcException) { }
            });

            Console.WriteLine("Type a message and then press enter.");

            while (true)
            {
                var msg = Console.ReadLine();
                var call = client.SendMessage(new ChatMessage { Author = username, RoomName = joinRoomName, Text = msg });

                if (call.Result == "leave")
                {
                    cts.Cancel();
                    await client.LeaveChatRoomAsync(new LeaveChatRoomRequest
                    {
                        Username = username
                    });

                    break;
                }
            }

            Console.WriteLine("Disconnecting");
            await reading;
        }
        else if (cmd == "3")
        {
            var roomNamesResponse = client.GetAllChatRooms(
                new GetAllRoomsRequest());
            int position = 1;
            Console.WriteLine("Available rooms: ");
            foreach (var item in roomNamesResponse.RoomName)
            {
                Console.WriteLine($"{position}: {item}");
                position++;
            }
            Console.WriteLine();
        }
        OptionsMenu();
        cmd = Console.ReadLine();
    }
}

void OptionsMenu()
{
    var sb = new StringBuilder();
    sb.AppendLine("Menu:");
    sb.AppendLine("Press 1 to create new room");
    sb.AppendLine("Press 2 to join room");
    sb.AppendLine("Press 3 to show existing rooms");
    Console.WriteLine(sb.ToString());
}