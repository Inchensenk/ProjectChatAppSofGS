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
    /// DTO: ответ на запрос регистрации пользователя в аккаунте
    /// </summary>
    [ProtoContract]
    public class SignUpResponseDTO
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [ProtoMember(1)]
        public int UserId { get; init; }

        /// <summary>
        /// Статус ответа
        /// </summary>
        [ProtoMember(2)]
        public NetworkResponseStatus Status { get; init; }
    }
}
