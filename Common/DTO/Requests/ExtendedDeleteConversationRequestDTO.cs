using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Requests
{
    /// <summary>
    /// DTO: расширенный запрос от клиента серверу на удаление диалога
    /// </summary>
    [ProtoContract]
    public class ExtendedDeleteConversationRequestDTO
    {
        /// <summary>
        /// Идентификатор беседы, которую можно удалить
        /// </summary>
        [ProtoMember(1)]
        public int ConversationId { get; init; }

        /// <summary>
        /// Идентификатор пользователя, удалившего диалог
        /// </summary>
        [ProtoMember(2)]
        public int UserId { get; init; }

        /// <summary>
        /// Перегрузка ToString()
        /// </summary>
        /// <returns>Строковое представление класса</returns>
        public override string ToString()
        {
            return $"Пользователь - Id: {UserId} отправил запрос на удаление диалога - Id: {ConversationId}.";
        }
    }
}
