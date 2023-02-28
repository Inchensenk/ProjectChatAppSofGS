using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.RequestResponse.Requests
{
    /// <summary>
    /// Запрос сервера (на удалении сообщения) к клиентскому приложению  
    /// </summary>
    public class DeleteMessageRequest
    {
        /// <summary>
        /// Идентификатор сообщения
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// Идентификатор беседы в котором хранится сообщение
        /// </summary>
        public int ConversationId { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public DeleteMessageRequest()
        {
            MessageId= 0;
            ConversationId= 0;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="messageId">Идентификатор сообщения</param>
        /// <param name="conversationId">Идентификатор беседы</param>
        public DeleteMessageRequest(int messageId, int conversationId)
        {
            MessageId = messageId;
            ConversationId = conversationId;
        }
    }
}
