using Chat.Domain;

internal class Program
{
    private static void Main(string[] args)
    {

        var app = new ChatApp();

        var testUser = app.CreateUser("testUser");
        var chatRoom = app.CreateChatRoom("testRoom");

        testUser.Join(chatRoom);

        testUser.Leave(chatRoom);

    }
}