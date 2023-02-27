using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestResponse.Request
{
    /// <summary>
    /// Запрос сервера к клиенту на удаление беседы
    /// </summary>
    public class DeleteConversationRequest
    {
        /// <summary>
        /// Идентификатор беседы
        /// </summary>
        public int ConversationId { get; init; }

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="conversationId">Идентификатор беседы</param>
        public DeleteConversationRequest(int conversationId)
        {
            ConversationId = conversationId;
        }

    }
}
