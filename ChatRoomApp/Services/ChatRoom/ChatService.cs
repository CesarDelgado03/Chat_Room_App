using ChatRoomApp.Data;
using ChatRoomApp.Helpers;
using ChatRoomApp.Infrastructure.Bot;
using ChatRoomApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoomApp.Core.Services.ChatRoom
{
    public class ChatService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRabbitMQService _mQService;
        public ChatService(ApplicationDbContext context,
            IRabbitMQService mQService)
        {
            _context = context;
            _mQService = mQService;
        }

        public async Task<List<ChatMessage>> GetMessages(int count)
        {
            return await _context.ChatMessages
               .Include(m => m.ChatRoomUser)
               .OrderByDescending(m => m.DateSent)
               .Take(count)
               .OrderBy(m => m.DateSent)
               .ToListAsync();
        }

        public async Task SendMessage(ChatMessage message)
        {
            if (message.IsCommand())
            {
                SendMessageToQueue(message);
            }
            else
            {
                await SendMessageToDb(message);
            }
        }

        private async Task SendMessageToDb(ChatMessage model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        private void SendMessageToQueue(ChatMessage model)
        {
            var command = model.GetCommand();
            //TODO send command to rabbitMQ
            _mQService.Send(command);
        }
    }
}
