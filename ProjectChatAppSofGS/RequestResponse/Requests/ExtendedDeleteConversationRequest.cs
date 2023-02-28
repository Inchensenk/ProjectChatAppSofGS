using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.RequestResponse.Requests
{

    public class ExtendedDeleteConversationRequest
    {
        /// <summary>
        /// Идентификатор беседы, которую будем удалять
        /// </summary>
        public int ConversationId { get; init; }

        /// <summary>
        /// Идентификатор пользователя который удалил диалог
        /// </summary>
        public int UserId { get; init; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="conversationId">Идентификатор диалога</param>
        /// <param name="userId">Идентификатор пользователя</param>
        public ExtendedDeleteConversationRequest(int conversationId, int userId)
        {
            ConversationId = conversationId;
            UserId = userId;
        }

    }
}
