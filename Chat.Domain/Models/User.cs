using Chat.Domain.Models;
using System;
using System.Linq;

namespace Chat.Domain
{
    public class User
    {
        private IMessageWriter _messageWriter;

        public User(string username, IMessageWriter messageWriter)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentException($"'{nameof(username)}' cannot be null or empty.", nameof(username));

            Username = username;
            _messageWriter = messageWriter ?? throw new ArgumentNullException(nameof(messageWriter));
        }
        public string Username { get; }

        public ChatRoom Room { get; private set; }

        public IMessageWriter MessageWriter => _messageWriter;

        public ConnectedUserToChatRoom JoinRoom(ChatRoom room)
        {
            if (room is null) return new ConnectedUserToChatRoom(false, Username, $"This room, doesnt exist");

            var success = room.ConnectUser(this);
            if (success)
            {
                Room = room;
                return new ConnectedUserToChatRoom(true, Username, Room.Name);
            }

            return new ConnectedUserToChatRoom(false, Username, Room.Name, $"User with that username '{Username}', already exist");
        }

        public void LeaveRoom()
        {
            Room?.DisconnectUser(this);
            Room = null;
        }

        public void SendMessage(string text)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentException($"'{nameof(text)}' cannot be null or empty.", nameof(text));

            Room.PublishMessage(new Message(Username, text, Room.Name));
        }

        public void ReceiveMessage(Message message)
        {
            if (message is null) throw new ArgumentNullException(nameof(message));

            _messageWriter.WriteMessageAsync(message).GetAwaiter().GetResult();
        }

        public void SetWriter(IMessageWriter messageWriter)
        {
            _messageWriter = messageWriter ?? throw new ArgumentNullException(nameof(messageWriter));
        }
    }
}