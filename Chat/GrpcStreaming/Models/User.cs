using Grpc.Core;
namespace GrpcStreaming.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IAsyncStreamWriter<ChatMessage> Stream { get; set; }
    }
}
