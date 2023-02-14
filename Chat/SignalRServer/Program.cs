using Chat.Domain.Models;
using Chat.Domain;
using SignalRServer.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ChatServerAppService>();
builder.Services.AddSingleton<Server>();
builder.Services.AddTransient<IMessageWriter, TextWriterMessageWriter>();
builder.Services.AddTransient<IMessagePublisher, SignalRMessagePublisher>();
builder.Services.AddSingleton(Console.Out);

builder.Services.AddSignalR();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();
app.MapHub<ChatHub>("/chatHub");

app.Run();