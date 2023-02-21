using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Requests
{
    /// <summary>
    /// DTO: запрос на удаление сообщения от сервера клиенту
    /// </summary>
    [ProtoContract]
    public class DeleteMessageRequestDTO
    {
        /// <summary>
        /// Идентификатор сообщения
        /// </summary>
        [ProtoMember(1)]
        public int MessageId { get; init; }

        /// <summary>
        /// Идентификатор диалога, в котором существует сообщение
        /// </summary>
        [ProtoMember(2)]
        public int DialogId { get; init; }
    }
}
