
using Chat.Grpc.Client.Protos;
using Grpc.Core;
using Grpc.Net.Client;
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

if (userConnectResponse.Success == true)
{
    Console.WriteLine("Options:");
    Console.WriteLine("Press 1 to create new room");
    Console.WriteLine("Press 2 to join room");
    Console.WriteLine("Press 3 to show existing rooms");

    var command = Console.ReadLine();

    while (true)
    {
        if (command == "1")
        {
            Console.WriteLine("Enter chat room name to create new");
            var name = Console.ReadLine();

            var createChatRoomResponse = await client.CreateChatRoomAsync(new CreateChatRoomRequest
            {
                RoomName = name,
                Username = username

            });
            Console.WriteLine(createChatRoomResponse.Success);
            Console.WriteLine(createChatRoomResponse.Reason);
            break;
        }
        else if (command == "2")
        {
            Console.WriteLine("Enter chat room name to join it");
            var name = Console.ReadLine();
            var joinChatRoomResponse = await client.JoinChatRoomAsync(new JoinChatRoomRequest
            {
                Username = username,
                RoomName = name
            });

            Console.WriteLine(joinChatRoomResponse.Success);
            Console.WriteLine(joinChatRoomResponse.Reason);
            Console.WriteLine(joinChatRoomResponse.Username);
            Console.ReadLine();

            break;
        }
        else if (command == "3")
        {
            var allRoomsResponse = await client.GetAllChatRoomsAsync(new GetAllRoomsRequest());
            foreach (var room in allRoomsResponse)
            {
                Console.WriteLine(room);
            }
            
        }
        else
        {
            Console.WriteLine("Invalid command!");
        }
        command = Console.ReadLine();
    }
}





var leaveChatRoomResponse = await client.LeaveChatRoomAsync(new LeaveChatRoomRequest
{
    Username= username,
});

Console.WriteLine(leaveChatRoomResponse.Success);
Console.WriteLine(leaveChatRoomResponse.Username);