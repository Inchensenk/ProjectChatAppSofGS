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
    /// DTO: ответ на запрос регистрации
    /// </summary>
    [ProtoContract]
    public class SignInResponseDTO
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        [ProtoMember(1)]
        public UserDTO? User { get; init; }

        /// <summary>
        /// Список диалогов пользователя
        /// </summary>
        [ProtoMember(2)]
        public List<ConversationDTO> ConversationListinc { get; init; }

        /// <summary>
        /// Статус ответа
        /// </summary>
        [ProtoMember(3)]
        public NetworkResponseStatus Status { get; init; }

        /// <summary>
        /// Контекст ошибки, если файл ответа неудачный
        /// </summary>
        [ProtoMember(4)]
        public SignInFailContext FailContext { get; init; }

        public SignInResponseDTO()
        {
            ConversationListinc = new List<ConversationDTO>();
        }
    }
}
