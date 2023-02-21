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
    /// DTO: ответ на запрос о поиске пользователя в списке зарегестрированных в аккаунте
    /// </summary>
    [ProtoContract]
    public class UserSearchResponseDTO
    {
        /// <summary>
        /// Пользователи, удовлетворяющие поиску
        /// </summary>
        [ProtoMember(1)]
        public List<UserDTO> RelevantUsers { get; init; }

        /// <summary>
        /// Статус ответа
        /// </summary>
        [ProtoMember(2)]
        public NetworkResponseStatus Status { get; init; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public UserSearchResponseDTO()
        {
            RelevantUsers = new List<UserDTO>();
        }
    }
}
