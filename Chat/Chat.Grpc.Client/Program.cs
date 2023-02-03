// See https://aka.ms/new-console-template for more information
using Chat.Grpc.Client.Protos;
using Grpc.Core;
using Grpc.Net.Client;


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


Console.WriteLine("Enter name, to create a chat room");
var name =  Console.ReadLine();

var createChatRoomResponse = await client.CreateChatRoomAsync(new CreateChatRoomRequest
{
    RoomName = name,
    Username = username

});
Console.WriteLine(createChatRoomResponse.Success);
Console.WriteLine(createChatRoomResponse.Reason);


var joinChatRoomResponse = await client.JoinChatRoomAsync(new JoinChatRoomRequest
{
    Username = username,
    RoomName = name
});

Console.WriteLine(joinChatRoomResponse.Success);
Console.WriteLine(joinChatRoomResponse.Reason);
Console.WriteLine(joinChatRoomResponse.Username);
Console.ReadLine();

var leaveChatRoomResponse = await client.LeaveChatRoomAsync(new LeaveChatRoomRequest
{
    Username= username,
});

Console.WriteLine(leaveChatRoomResponse.Success);
Console.WriteLine(leaveChatRoomResponse.Username);