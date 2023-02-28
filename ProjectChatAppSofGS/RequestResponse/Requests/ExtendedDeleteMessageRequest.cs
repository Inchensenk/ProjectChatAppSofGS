using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.RequestResponse.Requests
{
    /// <summary>
    /// Расширенный запрос на удаление сообщения от клиента к серверу
    /// </summary>
    public class ExtendedDeleteMessageRequest
    {
        /// <summary>
        /// Идентификатор сообщения
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// Идентификатор беседы,хранящей сообщение
        /// </summary>
        public int ConversationId { get; set; }

        /// <summary>
        /// Идентификатор пользователя, удалившего сообщение
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ExtendedDeleteMessageRequest()
        {
            MessageId = 0;
            ConversationId = 0;
            UserId = 0;
        }

        /// <summary>
        /// /Конструктор с параметрами
        /// </summary>
        /// <param name="messageId">Идентификатор сообщения</param>
        /// <param name="conversationId">Идентификатор беседы</param>
        /// <param name="userId">Идентификатор пользователя</param>
        public ExtendedDeleteMessageRequest(int messageId, int conversationId, int userId)
        {
            MessageId = messageId;
            ConversationId = conversationId;
            UserId = userId;
        }

    }
}
