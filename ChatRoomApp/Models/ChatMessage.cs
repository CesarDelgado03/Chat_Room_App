using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoomApp.Models
{
    public class ChatMessage
    {
        public long Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public DateTime DateSent { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string UserId { get; set; }
        public virtual ChatRoomUser ChatRoomUser { get; set; }
    }
}
