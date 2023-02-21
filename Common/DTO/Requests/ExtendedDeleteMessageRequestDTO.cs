using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Requests
{
    /// <summary>
    /// DTO: расширенный запрос на удаление сообщения от коиента серверу
    /// </summary>
    [ProtoContract]
    public class ExtendedDeleteMessageRequestDTO
    {
        /// <summary>
        /// Сообщение
        /// </summary>
        [ProtoMember(1)]
        public int MessageId { get; init; }

        /// <summary>
        /// Идентификатор диалога, в котором существует сообщение
        /// </summary>
        [ProtoMember(2)]
        public int ConversationId { get; init; }

        /// <summary>
        /// Пользователь, удаливший сообщение
        /// </summary>
        [ProtoMember(3)]
        public int UserId { get; init; }

        /// <summary>
        /// Перегрузка ToString()
        /// </summary>
        /// <returns>Строковое представление класса</returns>
        public override string ToString()
        {
            return $"Id пользователя, удалившего сообщение: {UserId}. Id сообщения: {MessageId}. Id диалога: {ConversationId}.";
        }
    }
}
