using Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestResponse.Responses
{
    /// <summary>
    /// Ответ на запрос создания новой беседы
    /// </summary>
    public class CreateConversationResponse : Response
    {
        /// <summary>
        /// Идентификатор созданной беседы
        /// </summary>
        public int ConversationId { get; init; }

        /// <summary>
        /// Идентификатор сообщения
        /// </summary>
        public int MessageId { get; init; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public CreateConversationResponse() : base() { }

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="status">Статус ответа</param>
        public CreateConversationResponse(NetworkResponseStatus status) : base(status) { }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="conversationId">Идентификатор созданного диалога</param>
        /// <param name="messageId">Идентификатор первого сообщения</param>
        public CreateConversationResponse(int conversationId, int messageId, NetworkResponseStatus status) : base(status)
        {
            ConversationId = conversationId;
            MessageId = messageId;
        }
    }
}
