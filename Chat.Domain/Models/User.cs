using Chat.Domain.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Chat.Domain
{
    public class User
    {
        private readonly IMessageWriter _messageWriter;
        public User(string username, IMessageWriter messageWriter)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentException($"'{nameof(username)}' cannot be null or empty.", nameof(username));

            Username = username;
            _messageWriter = messageWriter ?? throw new ArgumentNullException(nameof(messageWriter));
        }
        public string Username { get; }

        public ChatRoom Room { get; private set; }
        public Server Server { get; private set; }
        public void CreateRoom(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            Server.CreateChatRoom(name, Username);
        }

        public void JoinRoom(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));

            if (Server.ChatRooms.Any(r => r.Name == name) == false)
                return;
            Room = Server.ChatRooms.First(r => r.Name == name);
            Room.ConnectUser(this);
        }

        public void JoinRoom(ChatRoom room)
        {
            if (room is null) throw new ArgumentNullException(nameof(room));

            Room = room;
        }

        public void LeaveRoom()
        {
            Room.DisconnectUser(this);
        }

        public void SendMessage(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException($"'{nameof(text)}' cannot be null or empty.", nameof(text));

            Room.ReceiveMessageFromUser(text, Username);
        }

        public void ReceiveMessage(Message message)
        {
            if (message is null)
                throw new ArgumentNullException(nameof(message));
            _messageWriter.WriteMessage(message);
        }

    }
}