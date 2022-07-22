using Microsoft.AspNetCore.SignalR;
using SignalRExamp.Interface;

namespace SignalRExamp.Hubs
{
    public class MyHub:Hub<IMessageClient>
    {
        static List<string> clients = new List<string>();
        //public async Task SendMessageAsync(string message)
        //{
        //    await Clients.All.SendAsync("receiveMessage", message);
        //}

        public override async Task OnConnectedAsync() //Hub a biri bağlandığında çalışan fonk.
        {
            clients.Add(Context.ConnectionId);
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userJoined",Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)//Hub dan biri ayrıldığında çalışan fonk.
        {
            clients.Remove(Context.ConnectionId);
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserLeaved(Context.ConnectionId);
        }
        
    }
}
