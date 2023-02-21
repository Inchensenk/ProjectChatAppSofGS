using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Requests
{
    /// <summary>
    /// DTO: запрос на отправку сообщения пользователям
    /// </summary>
    [ProtoContract]
    public class SendMessageRequestDTO
    {
        /// <summary>
        /// Сообщение
        /// </summary>
        [ProtoMember(1)]
        public MessageDTO Message { get; init; }

        /// <summary>
        /// Идентификатор диалога, в котором существует сообщение
        /// </summary>
        [ProtoMember(2)]
        public int ConversationId { get; init; }

        public SendMessageRequestDTO()
        {
            Message = null!;
        }

        /// <summary>
        /// Перегрузка ToString()
        /// </summary>
        /// <returns>Строковое представление класса</returns>
        public override string ToString()
        {
            return $"Id диалога: {ConversationId}. Id отправителя: {Message.FromUser.Id}. Текст сообщения: {Message.MessageText}";
        }
    }
}
