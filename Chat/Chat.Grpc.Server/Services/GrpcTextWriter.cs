using Chat.Domain.Models;
using Chat.Grpc.Server.Protos;
using Grpc.Core;

namespace Chat.Grpc.Server.Services
{
    public class GrpcTextWriter : IMessageWriter
    {
        private readonly IServerStreamWriter<ChatMessage> responseStream;


        public GrpcTextWriter(IServerStreamWriter<ChatMessage> responseStream)
        {
            this.responseStream = responseStream;
        }

        public async Task WriteMessageAsync(Message message)
        {
            await responseStream.WriteAsync(new ChatMessage
            {
                Author = message.Author,
                Text = message.Text,
                RoomName = message.Room
            });
        }
    }
}