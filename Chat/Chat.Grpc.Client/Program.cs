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


    Console.WriteLine("Enter name to create new chat room");
    var newRoomName = Console.ReadLine();

    var createChatRoomResponse = await client.CreateChatRoomAsync(new CreateChatRoomRequest
    {
        RoomName = newRoomName,
        Username = username

    });

    Console.WriteLine(createChatRoomResponse.Success);
    Console.WriteLine(createChatRoomResponse.Reason);

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

    Console.WriteLine("Starting to send messages");
    Console.WriteLine("Type a message to echo then press enter.");

    while (true)
    {
        var msg = Console.ReadLine();
        var call = client.SendMessage(new ChatMessage { Author = username, RoomName = joinRoomName, Text = msg });
        if (string.IsNullOrEmpty(msg))
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
    //var allRoomsNames = await client.GetAllChatRoomsNamesAsync();
}




//var leaveChatRoomResponse = await client.LeaveChatRoomAsync(new LeaveChatRoomRequest
//{
//    Username = username,
//});

//Console.WriteLine(leaveChatRoomResponse.Success);
//Console.WriteLine(leaveChatRoomResponse.Username);