using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.RequestResponse.Requests
{
    /// <summary>
    /// Запрос от клиента для сервера на отправку сообщения 
    /// </summary>
    public class SendMessageRequest
    {
        /// <summary>
        /// Сообщение
        /// </summary>
        public Message Message { get; init; }

        /// <summary>
        /// Идентификатор беседы, в котором существует сообщение
        /// </summary>
        public int ConversationId { get; init; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="conversationId">Идентификатор беседы</param>
        public SendMessageRequest(Message message, int conversationId)
        {
            Message = message;
            ConversationId = conversationId;
        }

    }
}
