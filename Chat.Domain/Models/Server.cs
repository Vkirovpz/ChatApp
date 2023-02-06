using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Domain.Models
{
    public record ConnectedUser(bool IsConnected, string Username, string Reason = default);
    public record ConnectedUserToChatRoom(bool IsConnected, string Username, string Roomname, string Reason = default);
    public record DisconnectedUser(bool IsDisconnected, string Username);
    public record CreatedRoom(bool IsCreated, string RoomName, string Reason = default);

    public class Server
    {
        private readonly IMessageWriter _messageWriter;
        private readonly List<ChatRoom> _rooms = new List<ChatRoom>();
        private readonly List<User> _users = new List<User>();

        public IEnumerable<ChatRoom> ChatRooms => _rooms.AsReadOnly();
        public IEnumerable<User> Users => _users.AsReadOnly();

        public Server(IMessageWriter messageWriter)
        {
            _messageWriter = messageWriter;
        }

        public ConnectedUser ConnectUser(string username)
        {
            if (username is null) throw new ArgumentNullException(nameof(username));
            if (IsUserConnected(username))
                return new ConnectedUser(false, username, "Username duplicate");
             
             var user = new User(username, _messageWriter);
             _users.Add(user);

            return new ConnectedUser(true, username);
        }

        public CreatedRoom CreateChatRoom(string name, string username)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException($"'{nameof(username)}' cannot be null or whitespace.", nameof(username));

            if (IsUserConnected(username) == false)
                return new CreatedRoom(false, name, $"User '{username}' is not connected to the chat server.");

            if (_rooms.Any(r => r.Name == name))
                return new CreatedRoom(false, name, $"Room with name '{name}' already exist.");
                
            var room = new ChatRoom(name);
            _rooms.Add(room);

            return new CreatedRoom(true, room.Name);
        }

        public IEnumerable<string> GetAllChatRoomsNames() => ChatRooms.Select(x => x.Name);

        public bool IsUserConnected(string username) => _users.Any(u => u.Username == username);

        public User GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException($"'{nameof(username)}' cannot be null or whitespace.", nameof(username));
            return _users.First(u => u.Username == username);
        }

        public ChatRoom GetChatRoomByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            return _rooms.First(r => r.Name == name);
        }
    }
}