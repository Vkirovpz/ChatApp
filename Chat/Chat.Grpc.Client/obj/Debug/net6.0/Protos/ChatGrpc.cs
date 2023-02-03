// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/chat.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Chat.Grpc.Client.Protos {
  public static partial class ChatServer
  {
    static readonly string __ServiceName = "chat.ChatServer";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Chat.Grpc.Client.Protos.ConnectUserRequest> __Marshaller_chat_ConnectUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Client.Protos.ConnectUserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Chat.Grpc.Client.Protos.ConnectUserResponse> __Marshaller_chat_ConnectUserResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Client.Protos.ConnectUserResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Chat.Grpc.Client.Protos.CreateChatRoomRequest> __Marshaller_chat_CreateChatRoomRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Client.Protos.CreateChatRoomRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Chat.Grpc.Client.Protos.CreateChatRoomResponse> __Marshaller_chat_CreateChatRoomResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Client.Protos.CreateChatRoomResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Chat.Grpc.Client.Protos.JoinChatRoomRequest> __Marshaller_chat_JoinChatRoomRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Client.Protos.JoinChatRoomRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Chat.Grpc.Client.Protos.JoinChatRoomResponse> __Marshaller_chat_JoinChatRoomResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Client.Protos.JoinChatRoomResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Chat.Grpc.Client.Protos.LeaveChatRoomRequest> __Marshaller_chat_LeaveChatRoomRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Client.Protos.LeaveChatRoomRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Chat.Grpc.Client.Protos.LeaveChatRoomResponse> __Marshaller_chat_LeaveChatRoomResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Client.Protos.LeaveChatRoomResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Chat.Grpc.Client.Protos.GetAllRoomsRequest> __Marshaller_chat_GetAllRoomsRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Client.Protos.GetAllRoomsRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Chat.Grpc.Client.Protos.ListRoomsResponse> __Marshaller_chat_ListRoomsResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Client.Protos.ListRoomsResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Chat.Grpc.Client.Protos.ConnectUserRequest, global::Chat.Grpc.Client.Protos.ConnectUserResponse> __Method_ConnectUser = new grpc::Method<global::Chat.Grpc.Client.Protos.ConnectUserRequest, global::Chat.Grpc.Client.Protos.ConnectUserResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ConnectUser",
        __Marshaller_chat_ConnectUserRequest,
        __Marshaller_chat_ConnectUserResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Chat.Grpc.Client.Protos.CreateChatRoomRequest, global::Chat.Grpc.Client.Protos.CreateChatRoomResponse> __Method_CreateChatRoom = new grpc::Method<global::Chat.Grpc.Client.Protos.CreateChatRoomRequest, global::Chat.Grpc.Client.Protos.CreateChatRoomResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateChatRoom",
        __Marshaller_chat_CreateChatRoomRequest,
        __Marshaller_chat_CreateChatRoomResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Chat.Grpc.Client.Protos.JoinChatRoomRequest, global::Chat.Grpc.Client.Protos.JoinChatRoomResponse> __Method_JoinChatRoom = new grpc::Method<global::Chat.Grpc.Client.Protos.JoinChatRoomRequest, global::Chat.Grpc.Client.Protos.JoinChatRoomResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "JoinChatRoom",
        __Marshaller_chat_JoinChatRoomRequest,
        __Marshaller_chat_JoinChatRoomResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Chat.Grpc.Client.Protos.LeaveChatRoomRequest, global::Chat.Grpc.Client.Protos.LeaveChatRoomResponse> __Method_LeaveChatRoom = new grpc::Method<global::Chat.Grpc.Client.Protos.LeaveChatRoomRequest, global::Chat.Grpc.Client.Protos.LeaveChatRoomResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "LeaveChatRoom",
        __Marshaller_chat_LeaveChatRoomRequest,
        __Marshaller_chat_LeaveChatRoomResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Chat.Grpc.Client.Protos.GetAllRoomsRequest, global::Chat.Grpc.Client.Protos.ListRoomsResponse> __Method_GetAllChatRooms = new grpc::Method<global::Chat.Grpc.Client.Protos.GetAllRoomsRequest, global::Chat.Grpc.Client.Protos.ListRoomsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllChatRooms",
        __Marshaller_chat_GetAllRoomsRequest,
        __Marshaller_chat_ListRoomsResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Chat.Grpc.Client.Protos.ChatReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for ChatServer</summary>
    public partial class ChatServerClient : grpc::ClientBase<ChatServerClient>
    {
      /// <summary>Creates a new client for ChatServer</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ChatServerClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ChatServer that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ChatServerClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ChatServerClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ChatServerClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Chat.Grpc.Client.Protos.ConnectUserResponse ConnectUser(global::Chat.Grpc.Client.Protos.ConnectUserRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ConnectUser(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Chat.Grpc.Client.Protos.ConnectUserResponse ConnectUser(global::Chat.Grpc.Client.Protos.ConnectUserRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_ConnectUser, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Chat.Grpc.Client.Protos.ConnectUserResponse> ConnectUserAsync(global::Chat.Grpc.Client.Protos.ConnectUserRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ConnectUserAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Chat.Grpc.Client.Protos.ConnectUserResponse> ConnectUserAsync(global::Chat.Grpc.Client.Protos.ConnectUserRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_ConnectUser, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Chat.Grpc.Client.Protos.CreateChatRoomResponse CreateChatRoom(global::Chat.Grpc.Client.Protos.CreateChatRoomRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateChatRoom(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Chat.Grpc.Client.Protos.CreateChatRoomResponse CreateChatRoom(global::Chat.Grpc.Client.Protos.CreateChatRoomRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CreateChatRoom, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Chat.Grpc.Client.Protos.CreateChatRoomResponse> CreateChatRoomAsync(global::Chat.Grpc.Client.Protos.CreateChatRoomRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateChatRoomAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Chat.Grpc.Client.Protos.CreateChatRoomResponse> CreateChatRoomAsync(global::Chat.Grpc.Client.Protos.CreateChatRoomRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CreateChatRoom, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Chat.Grpc.Client.Protos.JoinChatRoomResponse JoinChatRoom(global::Chat.Grpc.Client.Protos.JoinChatRoomRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return JoinChatRoom(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Chat.Grpc.Client.Protos.JoinChatRoomResponse JoinChatRoom(global::Chat.Grpc.Client.Protos.JoinChatRoomRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_JoinChatRoom, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Chat.Grpc.Client.Protos.JoinChatRoomResponse> JoinChatRoomAsync(global::Chat.Grpc.Client.Protos.JoinChatRoomRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return JoinChatRoomAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Chat.Grpc.Client.Protos.JoinChatRoomResponse> JoinChatRoomAsync(global::Chat.Grpc.Client.Protos.JoinChatRoomRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_JoinChatRoom, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Chat.Grpc.Client.Protos.LeaveChatRoomResponse LeaveChatRoom(global::Chat.Grpc.Client.Protos.LeaveChatRoomRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return LeaveChatRoom(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Chat.Grpc.Client.Protos.LeaveChatRoomResponse LeaveChatRoom(global::Chat.Grpc.Client.Protos.LeaveChatRoomRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_LeaveChatRoom, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Chat.Grpc.Client.Protos.LeaveChatRoomResponse> LeaveChatRoomAsync(global::Chat.Grpc.Client.Protos.LeaveChatRoomRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return LeaveChatRoomAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Chat.Grpc.Client.Protos.LeaveChatRoomResponse> LeaveChatRoomAsync(global::Chat.Grpc.Client.Protos.LeaveChatRoomRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_LeaveChatRoom, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Chat.Grpc.Client.Protos.ListRoomsResponse GetAllChatRooms(global::Chat.Grpc.Client.Protos.GetAllRoomsRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllChatRooms(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Chat.Grpc.Client.Protos.ListRoomsResponse GetAllChatRooms(global::Chat.Grpc.Client.Protos.GetAllRoomsRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAllChatRooms, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Chat.Grpc.Client.Protos.ListRoomsResponse> GetAllChatRoomsAsync(global::Chat.Grpc.Client.Protos.GetAllRoomsRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllChatRoomsAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Chat.Grpc.Client.Protos.ListRoomsResponse> GetAllChatRoomsAsync(global::Chat.Grpc.Client.Protos.GetAllRoomsRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAllChatRooms, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override ChatServerClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ChatServerClient(configuration);
      }
    }

  }
}
#endregion
