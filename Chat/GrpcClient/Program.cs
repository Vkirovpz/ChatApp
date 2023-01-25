using Grpc.Core;
using Grpc.Net.Client;
using GrpcClient;

class Program
{
    private static async Task Main(string[] args)
    {
        var input = new HelloRequest { Name = "Test" };
        var channel = GrpcChannel.ForAddress("https://localhost:5001");
        var client = new Greeter.GreeterClient(channel);

        var reply = await client.SayHelloAsync(input);

        Console.WriteLine(reply.Message);

        Console.ReadLine();
    }
}
