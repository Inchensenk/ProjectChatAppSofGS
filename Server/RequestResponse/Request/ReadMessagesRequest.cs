using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestResponse.Request
{
    public class ReadMessagesRequest
    {
       /// <summary>
       /// Список идентификаторов прочитанных сообщений
       /// </summary>
        public List<int> MessagesId { get; set; }

        /// <summary>
        /// Идентификатор беседы в которой содержаться сообщения
        /// </summary>
        public int ConversationId { get; set; }

        public ReadMessagesRequest(List<int> messagesId, int conversationId)
        {
            MessagesId = messagesId;
            ConversationId = conversationId;
        }

    }
}
