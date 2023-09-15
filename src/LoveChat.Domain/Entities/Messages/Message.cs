using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveChat.Domain.Entities.Messages
{
    public class Message : Auditable
    {
        public long SenderId { get; set; }

        public long ReseiverId { get; set; }

        public string ImagePath { get; set; } = string.Empty;
    }
}
