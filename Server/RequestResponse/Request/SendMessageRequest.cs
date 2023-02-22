using Server.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestResponse.Request
{
    public class SendMessageRequest
    {
        public Message Message { get; set; }

        public int ConversationId { get; set; }

        public SendMessageRequest(Message message, int conversationId)
        {
            Message = message;
            ConversationId = conversationId;
        }

        public SendMessageRequest()
        {
            Message = new Message();
            ConversationId = 0;
        }
    }
}
