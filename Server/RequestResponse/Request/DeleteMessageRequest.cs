using Server.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestResponse.Request
{
    /// <summary>
    /// Запрос удаления сообщения у клиента
    /// </summary>
    public class DeleteMessageRequest
    {
        public int MessageId { get; set; }

        public int ConversationId { get; set; }

        public DeleteMessageRequest()
        {
            MessageId = 0;
            ConversationId = 0;
        }
        public DeleteMessageRequest(int messageId, int conversationId)
        {
            MessageId = messageId;
            ConversationId = conversationId;
        }
    }
}
