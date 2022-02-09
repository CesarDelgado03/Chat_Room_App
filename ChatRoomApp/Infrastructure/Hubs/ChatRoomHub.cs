using ChatRoomApp.Helpers;
using ChatRoomApp.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoomApp.Infrastructure.Hubs
{
    public class ChatRoomHub : Hub
    {
        public async Task SendMessage(ChatMessage chatMessage)
        {
            if (!chatMessage.IsCommand())
            {
                await Clients.All.SendAsync(method:"receiveMessage", chatMessage);
            }
            
        }
    }
}
