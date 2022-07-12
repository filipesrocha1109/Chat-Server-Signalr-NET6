using Microsoft.AspNetCore.SignalR;

namespace SignalServer
{
    class MyHub : Hub
    {
        public async override Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            await Clients.All.SendAsync("Message", "Connected successfully!");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMsg(SendMessage request, string connectionId)
        {                
            await Clients.All.SendAsync("SendMsgResp", new SendMessage { Name = request.Name, Message = request.Message });
        }
    }

    public class SendMessage
    {
        public string? Name { get; set; }
        public string? Message { get; set; }

    }
}
