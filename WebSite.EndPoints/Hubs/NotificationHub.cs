using Microsoft.AspNetCore.SignalR;
using Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.EndPoint.Hubs
{
    public class NotificationHub:Hub, INotificationHub
    {
        public async Task SendNotification(string Notification)
        {
            await Clients.Caller.SendAsync("getNotification", Notification);
        }
        public override Task OnConnectedAsync()
        {
            var s = Context.ConnectionId;
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

    }
}
