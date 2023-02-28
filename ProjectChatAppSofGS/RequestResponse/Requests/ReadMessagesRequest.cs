using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.RequestResponse.Requests
{
    /// <summary>
    /// Запрос от сервера для клиента о прочтении сообщения 
    /// </summary>
    public class ReadMessagesRequest
    {
        /// <summary>
        /// Список Id прочитанных сообщений 
        /// </summary>
        public List<int> MessageListincId { get; set; }

        /// <summary>
        /// Id диалога которому принадлежат сообщения
        /// </summary>
        public int ConversationId { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ReadMessagesRequest()
        {
            MessageListincId= new List<int>();
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="messageListincId">Список идентификаторов прочитанных сообщений </param>
        /// <param name="conversationId">Идентификатор беседы в которой хранятся сообщения</param>
        public ReadMessagesRequest(List<int> messageListincId, int conversationId)
        {
            MessageListincId = messageListincId;
            ConversationId = conversationId;
        }

    }
}
