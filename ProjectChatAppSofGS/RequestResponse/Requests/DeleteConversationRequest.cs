using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.RequestResponse.Requests
{
    /// <summary>
    /// Запрос от сервера для клиентского приложения об удалении беседы
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
        /// <param name="conversationId">Идентификатор клиента</param>
        public DeleteConversationRequest(int conversationId)
        {
            ConversationId = conversationId;
        }
    }
}
