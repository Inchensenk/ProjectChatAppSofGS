using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.RequestResponse.Requests
{
    /// <summary>
    /// Расширенный запрос на прочтение сообщения от клиента к серверу
    /// </summary>
    public class ExtendedReadMessagesRequest
    {
        /// <summary>
        /// Список идентификаторов прочитанных сообщений 
        /// </summary>
        public List<int> MessageListincId { get; set; }

        /// <summary>
        /// Идентификатор пользователя прочитавшего сообщения
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Идентификатор беседы в которой хранятся сообщения
        /// </summary>
        public int ConversationId { get; set; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="messageListincId">Список идентификаторов сообщений</param>
        /// <param name="userId">Идентификатор пользователя прочитавшего сообщения</param>
        /// <param name="conversationId">Идентификатор беседы в которой хранятся сообщения</param>
        public ExtendedReadMessagesRequest(List<int> messageListincId, int userId, int conversationId)
        {
            MessageListincId = messageListincId;
            UserId = userId;
            ConversationId = conversationId;
        }

    }
}
