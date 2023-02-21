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
    /// DTO: ответ на запрос об отправке сообщения
    /// </summary>
    [ProtoContract]
    public class SendMessageResponseDTO
    {
        /// <summary>
        /// Идентификатор отправленного сообщения
        /// </summary>
        [ProtoMember(1)]
        public int MessageId { get; init; }

        /// <summary>
        /// Статус ответа
        /// </summary>
        [ProtoMember(2)]
        public NetworkResponseStatus Status { get; init; }
    }
}
