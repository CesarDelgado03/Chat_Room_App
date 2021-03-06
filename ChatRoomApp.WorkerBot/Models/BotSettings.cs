using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomApp.WorkerBot.Models
{
    class BotSettings
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public int RequestedConnectionTimeout { get; set; }
        public string InboundQueue { get; set; }
        public string OutboundQueue { get; set; }
        public string BotName { get; set; }
    }
}
