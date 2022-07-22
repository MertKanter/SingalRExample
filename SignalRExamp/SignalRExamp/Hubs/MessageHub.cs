using Microsoft.AspNetCore.SignalR;

namespace SignalRExamp.Hubs
{
    public class MessageHub:Hub
    {
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        //public async Task SendMessageAsync(string message, string groupName, IEnumerable<string> connectionIds)
        //public async Task SendMessageAsync(string message, IEnumerable<string> groups)
        public async Task SendMessageAsync(string message, string groupName)
        {

            #region caller

            // sadece serverea bildirim gönderen clientla ileştim kurar.
            //await Clients.Caller.SendAsync("receiveMessage", message);

            #endregion

            #region All
            //Servera bağlı olan tüm clientlar ile iletişim kurar.

            //await Clients.All.SendAsync("receiveMessage", message);

            #endregion

            #region Others
            //sadece servera bildirim gönderen client dışında server a bağlı olan tüm clieantlara gönderir.
            //await Clients.Others.SendAsync("receiveMessage", message);

            #endregion

            #region Hub Clients Metotları
            #region AllExcept
            //Belirtilen Clientler hariç servera bağlı olan tüm clientlara bildiride bulunulur.
            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);

            #endregion
            #region Client
            //Server a bağlı olan belirli bir clienta bildiride bulunulur.
            //await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);

            #endregion

            #region Clients
            //Server a bağlı olan clientlar arasında belirtilenlere bildiride bulunur.
            //await Clients.Clients(connectionIds).SendAsync("receiveMessage",message);

            #endregion

            #region Group

            //Belirtilen grouptaki tüm clieantlara bildiride bulunur.
            //önce grouplar oluşturulmalı ardından clieantlar grouplara subscribe olmalı
            //await Clients.Group(groupName).SendAsync("receiveMessage", message);

            #endregion

            #region GroupExcept
            //Belirtilen gruptaki, belirtilen clieantlar dışındaki tüm clieantlara mesaj iletmemeizi sağlayan fonksiyondur.
            //await Clients.GroupExcept(groupName, connectionIds).SendAsync("receiveMessage", message);


            #endregion

            #region Groups
            //Birden çok gruptaki clieantlara bildiride bulunmamızı sağlayan fonksiyondur.
            //await Clients.Groups(groups).SendAsync("receiveMessage", message);

            #endregion

            #region OtherInGroup

            //Bildiride bulunan client haricinde gruptaki tüm clieeantlara bildiride bulunan fonksiyondur.
            await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);

            #endregion

            #region User
            //tek bir authentication olan client ile iletişim kurar

            #endregion

            #region Users
            //birden fazla authentication olan client ile iletişim kurar


            #endregion

            #endregion
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }
        //Gelen connection id ve group name i gruba ekler.
        public async Task addGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}
