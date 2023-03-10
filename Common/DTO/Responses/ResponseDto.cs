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
    /// DTO: ответ на запрос серверу от клиента
    /// </summary>
    [ProtoContract]
    public class ResponseDTO
    {
        /// <summary>
        /// Статус ответа
        /// </summary>
        [ProtoMember(1)]
        public NetworkResponseStatus Status { get; init; }
    }
}
