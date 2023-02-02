using Chat.Domain;
using Chat.Domain.Models;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter server Ip/Host Address");
        var address = Console.ReadLine();
        using var messageWriter = new TextWriterMessageWriter(Console.Out);
        var server = new Server(address, messageWriter);
        server.InitTestRoomAndUser();

        Console.WriteLine("Enter username");
        var username = Console.ReadLine();
        var user = server.CreateUser(username);
        server.ConnectUser(username);

        var sb = new StringBuilder();
        sb.AppendLine("Options:");
        sb.AppendLine("Press 1 to show existing rooms");
        sb.AppendLine("Press 2 to create new room");
        Console.WriteLine(sb.ToString());

        var command = Console.ReadLine();

        while (true)
        {
            if (command == "1")
            {
                server.AllChatRooms();
                Console.WriteLine("Enter room name to join it:");
                var chatRoom = Console.ReadLine();
                user.JoinRoom(chatRoom);
                break;
            }
            else if (command == "2")
            {
                Console.WriteLine("Enter room name to create:");
                var roomName = Console.ReadLine();
                user.CreateRoom(roomName);
                break;
            }
            else
            {
                Console.WriteLine("Invalid command!");
                Console.WriteLine(sb.ToString());
            }
            command = Console.ReadLine();
        }
        

        Console.WriteLine("Write message:");
        var message = Console.ReadLine();
        while (string.Equals(message, "qw!", StringComparison.CurrentCultureIgnoreCase) == false)
        {
            user.SendMessage(message);
            message= Console.ReadLine();
        }

        user.LeaveRoom();

    }
}