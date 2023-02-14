using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

public class ChatHttpClient
{
    private readonly HttpClient client;

    public ChatHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<ConnectedUserResponse> ConnectUserAsync(string username)
    {
        var json = JsonSerializer.Serialize(username);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/connectUser", content);
        response.EnsureSuccessStatusCode();
        var connectedUser = await response.Content.ReadFromJsonAsync<ConnectedUserResponse>();
        return connectedUser;
    }

    public async Task<DisconnectedUserResponse> DisconnectUserAsync(string username)
    {
        var json = JsonSerializer.Serialize(username);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/leaveRoom", content);
        response.EnsureSuccessStatusCode();
        var disconnectedUser = await response.Content.ReadFromJsonAsync<DisconnectedUserResponse>();
        return disconnectedUser;
    }

    public async Task<CreatedRoomResponse> CreateRoomAsync(string username, string roomName)
    {
        var request = new CreateRoomRequest(username, roomName);
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/createRoom", content);
        response.EnsureSuccessStatusCode();
        var createdRoom = await response.Content.ReadFromJsonAsync<CreatedRoomResponse>();
        return createdRoom;
    }

    public async Task<ConnectedUserResponse> JoinRoomAsync(string username, string roomName)
    {
        var request = new JoinRoomRequest(username, roomName);
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/joinRoom", content);
        response.EnsureSuccessStatusCode();
        var connectedUserToChatRoom = await response.Content.ReadFromJsonAsync<ConnectedUserResponse>();
        return connectedUserToChatRoom;
    }

    public async Task<string> SendMessageAsync(string username, string message)
    {
        var request = new SendMessageRequest(username, message);
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/sendMessage", content);
        response.EnsureSuccessStatusCode();
        var emptyResponse = await response.Content.ReadAsStringAsync();
        return emptyResponse;
    }

    public async Task<List<string>> GetAllRoomNamesAsync()
    {
        var response = await client.GetAsync("/getAllRooms");
        response.EnsureSuccessStatusCode();
        var resp = await response.Content.ReadAsStringAsync();
        List<string> names = JsonSerializer.Deserialize<List<string>>(resp);
        return names;

    }

    public record CreateRoomRequest(string username, string roomName);
    public record CreatedRoomResponse(bool IsCreated, string RoomName, string Reason = default);
    public record UserRequest(string Username);
    public record ConnectedUserResponse(bool IsConnected, string Username, string Reason = null);
    public record DisconnectedUserResponse(bool IsDisconnected, string Username);
    public record JoinRoomRequest(string username, string roomName);
    public record SendMessageRequest(string username, string message);
}

