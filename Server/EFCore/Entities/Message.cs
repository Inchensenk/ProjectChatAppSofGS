using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.EFCore.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string FromNumber { get; set; }
        public string MessageText { get; set; }
        public DateTime SendDateTime { get; set; }

        public int ConversationId { get; set; }
        public Conversation? Conversation { get; set; }

        public Message()
        {
            FromNumber= null!;
            MessageText= null!;
        }
    }
}
