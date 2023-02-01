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
            Console.WriteLine("Enter Username");
            var username = Console.ReadLine();
            
            client.Join(username);

            Console.WriteLine();    
            Console.WriteLine("Enter Message");
            Console.WriteLine("Press Q to Exit");

            var message = Console.ReadLine();
            while (!string.Equals(message, "qw!", StringComparison.CurrentCultureIgnoreCase)) 
            {
                if (!string.IsNullOrEmpty(message))
                    client.SendMessage(message);

                message = Console.ReadLine();
            }

        }
    }
}
