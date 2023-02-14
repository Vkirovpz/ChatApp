using Chat.Domain;
using Chat.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMqProducer.Models;
using RabbitMqProducer.RabbitMQ;
using static RabbitMqProducer.Models.RequestModels;

namespace RabbitMqProducer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ChatServerAppService _chatServer;
        private readonly IMessageWriter messageWriter;

        public UsersController(ChatServerAppService chatService, IMessageWriter messageWriter)        
        {
            _chatServer = chatService;
            this.messageWriter = messageWriter;
        }

        [HttpPost("/connectUser")]
        public ConnectedUser ConnectUser([FromBody] string username)
        {
            var connectedUser = _chatServer.ConnectUser(username);
            return connectedUser;
        }

        [HttpPost("/leaveRoom")]
        public DisconnectedUser LeaveRoom([FromBody] string username)
        {
            var disconnectedUser = _chatServer.LeaveRoom(username);
            return disconnectedUser;
        }

        [HttpPost("/createRoom")]
        public CreatedRoom CreateChatRoom(CreateRoomRequest request)
        {
            var createdRoom = _chatServer.CreateChatRoom(request.roomName, request.username);
            return createdRoom;
        }

        [HttpPost("/sendMessage")]
        public void SendMessage(SendMessageRequest request)
        {
            _chatServer.SendMessage(request.username, request.message);
        }

        [HttpGet("/getAllRooms")]
        public IEnumerable<string> GetAllRooms()
        {
            var allRooms = _chatServer.GetAllRooms();
            return allRooms;
        }

        [HttpPost("/joinRoom")]
        public ConnectedUserToChatRoom JoinChatRoom(JoinRoomRequest request)
        {
            var connectedUser = _chatServer.JoinRoom(request.roomName, request.username, messageWriter);
            return connectedUser;
        }
    }
}
