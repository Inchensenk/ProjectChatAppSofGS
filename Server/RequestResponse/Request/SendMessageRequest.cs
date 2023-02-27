using Server.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestResponse.Request
{
    /// <summary>
    /// Запрос на отправку сообщений
    /// </summary>
    public class SendMessageRequest
    {
        /// <summary>
        /// Сообщения
        /// </summary>
        public Message Message { get; set; }

        /// <summary>
        /// Идентификатор беседы в которой хранится сообщение
        /// </summary>
        public int ConversationId { get; set; }

        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="conversationId">Идентификатор беседы</param>
        public SendMessageRequest(Message message, int conversationId)
        {
            Message = message;
            ConversationId = conversationId;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public SendMessageRequest()
        {
            Message = new Message();
            ConversationId = 0;
        }
    }
}
