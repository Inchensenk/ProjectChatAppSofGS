using Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.RequestResponse.Responses
{
    /// <summary>
    /// Ответ на запрос о создании новой беседы
    /// </summary>
    public class CreateConversationResponse : Response
    {

        /// <summary>
        /// Идентификатор созданной беседы
        /// </summary>
        public int ConversationId { get; init; }

        /// <summary>
        /// Идентификатор первого сообщения
        /// </summary>
        public int MessageId { get; init; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="сonversationId">Идентификатор созданной беседы</param>
        /// <param name="messageId">Идентификатор первого сообщения</param>
        public CreateConversationResponse(int сonversationId, int messageId, NetworkResponseStatus status) : base(status) 
        {
            ConversationId = сonversationId; 
            MessageId = messageId;
        }
    }
}
