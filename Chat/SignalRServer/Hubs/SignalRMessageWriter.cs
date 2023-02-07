using Chat.Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Hubs
{
    public class SignalRMessageWriter : IMessageWriter
    {
        private readonly IClientProxy clientProxy;

        public SignalRMessageWriter(IClientProxy clientProxy)
        {
            this.clientProxy = clientProxy;
        }

        public Task WriteMessageAsync(Message message)
        {
            return clientProxy.SendAsync("ReceiveMessage", message.Author, message.Text);
        }
    }
}
