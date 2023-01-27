//using Grpc.Core;
//using GrpcStreaming.Proto;

//namespace GrpcStreaming.Services
//{
//    public class MessageStreamService : StreamService.StreamServiceBase
//    {
//        private ILogger<MessageStreamService> _logger;

//        public MessageStreamService(ILogger<MessageStreamService> logger)
//        {
//            _logger = logger;
//        }
//        public override async Task StartStreaming(IAsyncStreamReader<StreamMessage> requestStream, IServerStreamWriter<StreamMessage> responseStream, ServerCallContext context)
//        {
//            if (requestStream != null)
//            {
//                if (!await requestStream.MoveNext())
//                    return;
//            }

//            try
//            {
//                if (!string.IsNullOrEmpty(requestStream.Current.Message))
//                {
//                    if (string.Equals(requestStream.Current.Message, "qw!", StringComparison.OrdinalIgnoreCase))
//                        return;

//                }

//                var message = requestStream.Current.Message;
//                Console.WriteLine($"User: {requestStream.Current.Username}  Message: {requestStream.Current.Message}");
//                await responseStream.WriteAsync(new StreamMessage
//                {
//                    Username = requestStream.Current.Username,
//                    Message = $"Reply stream from the server to {requestStream.Current.Username}"
//                });
//            }
//            catch (Exception e)
//            {
//                _logger.LogInformation(e.Message);
//            }



//        }
//    }
//}
