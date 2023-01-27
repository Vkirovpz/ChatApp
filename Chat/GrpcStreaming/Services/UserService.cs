using Grpc.Core;

namespace GrpcStreaming.Services
{
    public class UserService : GrpcStreaming.UserService.UserServiceBase
    {
        private readonly IChatRoomService _chatRoomService;


        public UserService(IChatRoomService chatRoomService)
        {
            _chatRoomService = chatRoomService;
        }

        public override async Task<JoinUserReply> JoinUserChat(JoinUserRequest request, ServerCallContext context)
        {
            return new JoinUserReply { RoomId = await _chatRoomService.AddUserToChatRoomAsync(request.User) };
        }

        public override async Task SendMessageToChatRoom(IAsyncStreamReader<ChatMessage> requestStream, IServerStreamWriter<ChatMessage> responseStream,
            ServerCallContext context)
        {
            var httpContext = context.GetHttpContext();

            if (!await requestStream.MoveNext())
            {
                return;
            }

            _chatRoomService.ConnectUserToChatRoom(requestStream.Current.RoomId, Guid.Parse(requestStream.Current.UserId), responseStream);
            var user = requestStream.Current.UserName;

            try
            {
                while (await requestStream.MoveNext())
                {
                    if (!string.IsNullOrEmpty(requestStream.Current.Message))
                    {
                        if (string.Equals(requestStream.Current.Message, "qw!", StringComparison.OrdinalIgnoreCase))
                        {
                            break;
                        }
                        await _chatRoomService.BroadcastMessageAsync(requestStream.Current);
                    }
                }
            }
            catch (IOException)
            {
                _chatRoomService.DisconnectUser(requestStream.Current.RoomId, Guid.Parse(requestStream.Current.UserId));
            }
        }
    }
}
