using GrpcStreaming.Providers;
using GrpcStreaming.Services;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddGrpc();
        builder.Services.AddTransient<IChatRoomService, ChatRoomService>();
        builder.Services.AddSingleton<IChatRoomProvider, ChatRoomProvider>();


        var app = builder.Build();

        app.MapGrpcService<UserService>();

        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        app.Run();
    }
}