// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/chat.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Chat.Grpc.Server.Protos {
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
    static readonly grpc::Marshaller<global::Chat.Grpc.Server.Protos.ConnectUserRequest> __Marshaller_chat_ConnectUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Server.Protos.ConnectUserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Chat.Grpc.Server.Protos.ConnectUserResponse> __Marshaller_chat_ConnectUserResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Server.Protos.ConnectUserResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Chat.Grpc.Server.Protos.CreateChatRoomRequest> __Marshaller_chat_CreateChatRoomRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Server.Protos.CreateChatRoomRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Chat.Grpc.Server.Protos.CreateChatRoomResponse> __Marshaller_chat_CreateChatRoomResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Server.Protos.CreateChatRoomResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Chat.Grpc.Server.Protos.JoinChatRoomRequest> __Marshaller_chat_JoinChatRoomRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Server.Protos.JoinChatRoomRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Chat.Grpc.Server.Protos.JoinChatRoomResponse> __Marshaller_chat_JoinChatRoomResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Server.Protos.JoinChatRoomResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Chat.Grpc.Server.Protos.LeaveChatRoomRequest> __Marshaller_chat_LeaveChatRoomRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Server.Protos.LeaveChatRoomRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Chat.Grpc.Server.Protos.LeaveChatRoomResponse> __Marshaller_chat_LeaveChatRoomResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Chat.Grpc.Server.Protos.LeaveChatRoomResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Chat.Grpc.Server.Protos.ConnectUserRequest, global::Chat.Grpc.Server.Protos.ConnectUserResponse> __Method_ConnectUser = new grpc::Method<global::Chat.Grpc.Server.Protos.ConnectUserRequest, global::Chat.Grpc.Server.Protos.ConnectUserResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ConnectUser",
        __Marshaller_chat_ConnectUserRequest,
        __Marshaller_chat_ConnectUserResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Chat.Grpc.Server.Protos.CreateChatRoomRequest, global::Chat.Grpc.Server.Protos.CreateChatRoomResponse> __Method_CreateChatRoom = new grpc::Method<global::Chat.Grpc.Server.Protos.CreateChatRoomRequest, global::Chat.Grpc.Server.Protos.CreateChatRoomResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateChatRoom",
        __Marshaller_chat_CreateChatRoomRequest,
        __Marshaller_chat_CreateChatRoomResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Chat.Grpc.Server.Protos.JoinChatRoomRequest, global::Chat.Grpc.Server.Protos.JoinChatRoomResponse> __Method_JoinChatRoom = new grpc::Method<global::Chat.Grpc.Server.Protos.JoinChatRoomRequest, global::Chat.Grpc.Server.Protos.JoinChatRoomResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "JoinChatRoom",
        __Marshaller_chat_JoinChatRoomRequest,
        __Marshaller_chat_JoinChatRoomResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Chat.Grpc.Server.Protos.LeaveChatRoomRequest, global::Chat.Grpc.Server.Protos.LeaveChatRoomResponse> __Method_LeaveChatRoom = new grpc::Method<global::Chat.Grpc.Server.Protos.LeaveChatRoomRequest, global::Chat.Grpc.Server.Protos.LeaveChatRoomResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "LeaveChatRoom",
        __Marshaller_chat_LeaveChatRoomRequest,
        __Marshaller_chat_LeaveChatRoomResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Chat.Grpc.Server.Protos.ChatReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ChatServer</summary>
    [grpc::BindServiceMethod(typeof(ChatServer), "BindService")]
    public abstract partial class ChatServerBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Chat.Grpc.Server.Protos.ConnectUserResponse> ConnectUser(global::Chat.Grpc.Server.Protos.ConnectUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Chat.Grpc.Server.Protos.CreateChatRoomResponse> CreateChatRoom(global::Chat.Grpc.Server.Protos.CreateChatRoomRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Chat.Grpc.Server.Protos.JoinChatRoomResponse> JoinChatRoom(global::Chat.Grpc.Server.Protos.JoinChatRoomRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Chat.Grpc.Server.Protos.LeaveChatRoomResponse> LeaveChatRoom(global::Chat.Grpc.Server.Protos.LeaveChatRoomRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(ChatServerBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_ConnectUser, serviceImpl.ConnectUser)
          .AddMethod(__Method_CreateChatRoom, serviceImpl.CreateChatRoom)
          .AddMethod(__Method_JoinChatRoom, serviceImpl.JoinChatRoom)
          .AddMethod(__Method_LeaveChatRoom, serviceImpl.LeaveChatRoom).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ChatServerBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_ConnectUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Chat.Grpc.Server.Protos.ConnectUserRequest, global::Chat.Grpc.Server.Protos.ConnectUserResponse>(serviceImpl.ConnectUser));
      serviceBinder.AddMethod(__Method_CreateChatRoom, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Chat.Grpc.Server.Protos.CreateChatRoomRequest, global::Chat.Grpc.Server.Protos.CreateChatRoomResponse>(serviceImpl.CreateChatRoom));
      serviceBinder.AddMethod(__Method_JoinChatRoom, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Chat.Grpc.Server.Protos.JoinChatRoomRequest, global::Chat.Grpc.Server.Protos.JoinChatRoomResponse>(serviceImpl.JoinChatRoom));
      serviceBinder.AddMethod(__Method_LeaveChatRoom, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Chat.Grpc.Server.Protos.LeaveChatRoomRequest, global::Chat.Grpc.Server.Protos.LeaveChatRoomResponse>(serviceImpl.LeaveChatRoom));
    }

  }
}
#endregion