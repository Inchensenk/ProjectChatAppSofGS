using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Requests
{
    /// <summary>
    /// DTO: Запрос на создание диалога
    /// </summary>
    [ProtoContract]
    public class CreateConversationRequestDTO
    {
        /// <summary>
        /// Список пользователей диалога
        /// </summary>
        [ProtoMember(1)]
        public List<int> UsersId { get; init; }

        public List<MessageDTO>  { get; init;}
    }
}
