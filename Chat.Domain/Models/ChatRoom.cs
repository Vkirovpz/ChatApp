using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Domain.Models
{
    public class ChatRoom
    {
        private readonly List<User> _usersInRoom = new List<User>();
        private readonly List<Message> chatHistory = new List<Message>();
        private readonly IMessagePublisher messagePublisher;

        public ChatRoom(string name, IMessagePublisher messagePublisher)
        {
            Name = name;
            this.messagePublisher = messagePublisher;
        }

        public IEnumerable<User> Users => _usersInRoom.AsReadOnly();

        public string Name { get; }

        public bool ConnectUser(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            if (_usersInRoom.Any(u => u.Username == user.Username))
                return false;

            try
            {
                messagePublisher.SubscribeAsync(user, this).GetAwaiter().GetResult();
                _usersInRoom.Add(user);
            }
            catch (Exception)
            {
                return false;
            }

            foreach (var msg in chatHistory)
            {
                user.ReceiveMessage(msg);
            }
            //messagePublisher.PublishAsync(new Message(user.Username, "User joined room",Name)).GetAwaiter().GetResult();

            return true;
        }

        public DisconnectedUser DisconnectUser(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));

            messagePublisher.UnsubscribeAsync(user).GetAwaiter().GetResult();
            _usersInRoom.Remove(user);

            return new DisconnectedUser(true, user.Username);
        }

        public IEnumerable<Message> GetAllMessages() => chatHistory.ToList();

        public void PublishMessage(Message message)
        {
            if (message is null) throw new ArgumentNullException(nameof(message));
            if (_usersInRoom.Any(u => u.Username == message.Author) == false)
                throw new InvalidOperationException($"Cannot publish message. Message author '{message.Author}' is not in chat room '{Name}'.");

            chatHistory.Add(message);
            messagePublisher.PublishAsync(message).GetAwaiter().GetResult();
            //foreach (var user in _usersInRoom.Where(u => u.Username != message.Author))
            //{
            //    user.ReceiveMessage(message);
            //}
        }
    }
}
