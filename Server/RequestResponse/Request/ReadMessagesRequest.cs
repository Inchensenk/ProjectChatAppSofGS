using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestResponse.Request
{
    /// <summary>
    /// Запрос сервера к клиенту о прочтении сообщения пользователем на другом клиенте
    /// </summary>
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

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="messagesId">Список идентификаторов прочитанных сообщений</param>
        /// <param name="conversationId">Идентификатор беседы в которой хранятся сообщения</param>
        public ReadMessagesRequest(List<int> messagesId, int conversationId)
        {
            MessagesId = messagesId;
            ConversationId = conversationId;
        }

    }
}
