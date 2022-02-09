using ChatRoomApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatRoomApp.Helpers
{
    public static class BotHelpers
    {
        public static bool IsCommand(this ChatMessage chatMessage)
        {

            return chatMessage.Message.StartsWith("/");
        }

        public static string GetCommand(this ChatMessage chatMessage)
        {
            return !chatMessage.IsCommand() ? null : chatMessage.Message;
        }
    }
}
