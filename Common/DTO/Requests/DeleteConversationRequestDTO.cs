using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Requests
{
    /// <summary>
    /// DTO: запрос от сервера клиенту на удаление диалога
    /// </summary>
    [ProtoContract]
    public class DeleteConversationRequestDTO
    {
        /// <summary>
        /// Идентификатор беседы
        /// </summary>
        [ProtoMember(1)]
        public int ConversationId { get; set; } 
    }
}
