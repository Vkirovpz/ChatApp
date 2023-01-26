using Chat.Domain;
using System;
using System.ServiceModel;


namespace Client
{
     class Program
    {
        static void Main(string[] args)
        {
            InstanceContext context = new InstanceContext(new MyCallback());
            Proxy.ChatServiceClient client = new Proxy.ChatServiceClient(context);

            //var chatApp = new ChatApp();
            //var room = chatApp.CreateChatRoom("TestRoom");
            //var room2 = chatApp.CreateChatRoom("TestRoom2");
            //Console.WriteLine("Enter UserName");
            //var username = Console.ReadLine();
            //var user = chatApp.CreateUser(username);
            //user.Join(room);
            //Console.WriteLine($"You entered Chat Room - {room.RoomName}");
            Console.WriteLine("Enter UserName");
            var username = Console.ReadLine();
            client.Join(username);

            Console.WriteLine();    
            Console.WriteLine("Enter Message");
            Console.WriteLine("Press Q to Exit");

            var message = Console.ReadLine();
            while (message != "Q") 
            {
                if (!string.IsNullOrEmpty(message))
                    client.SendMessage(message);

                message = Console.ReadLine();
            }

        }
    }
}
