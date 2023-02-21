using Common.Network;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Responses
{
    /// <summary>
    /// DTO: ответ на запрос о создании новой беседы
    /// </summary>
    [ProtoContract]
    public class CreateConversationResponseDTO
    {
        /// <summary>
        /// Идентификатор беседы
        /// </summary>
        [ProtoMember(1)]
        public int ConversationId { get; init; }

        /// <summary>
        /// Идентификатор первого сообщения
        /// </summary>
        [ProtoMember(2)]
        public int MessageId { get; init; }

        /// <summary>
        /// Статус ответа
        /// </summary>
        [ProtoMember(3)]
        public NetworkResponseStatus Status { get; init; }
    }
}
