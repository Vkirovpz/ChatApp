
using Grpc.Core;
using Grpc.Net.Client;
using GrpcStreaming.Protos;

Console.WriteLine("press enter to cont....");
Console.ReadLine();
using var channel = GrpcChannel.ForAddress("http://localhost:5001");
var client = new StreamService.StreamServiceClient(channel);
string username = "testuser";
using var stream = client.StartStreaming();
var response = Task.Run(async () =>

{
	await foreach (var rm in stream.ResponseStream.ReadAllAsync())
	{
		Console.WriteLine(rm.Message);
	}
});
Console.WriteLine("enter message to stream to server");
while (true)
{
	var text = Console.ReadLine();
	if (string.IsNullOrEmpty(text))
		break;
	await stream.RequestStream.WriteAsync(new StreamMessage
	{
		Username = username,
		Message = text
	});
}

Console.WriteLine("Disconnecting..");
await stream.RequestStream.CompleteAsync();
await response;
