using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Requests
{
    /// <summary>
    /// DTO: запрос на прочтение сообщения от клиента серверу
    /// </summary>
    [ProtoContract]
    public class ExtendedReadMessagesRequestDTO
    {
        /// <summary>
        /// Список идентификаторов прочитанных сообщений
        /// </summary>
        [ProtoMember(1)]
        public List<int> MessagesId { get; set; }

        /// <summary>
        /// Идентификатор пользователя прочитавшего сообщения
        /// </summary>
        [ProtoMember(2)]
        public int UserId { get; set; }

        /// <summary>
        /// Идентификатор диалога, которому принадлежат сообщения
        /// </summary>
        [ProtoMember(3)]
        public int ConversationId { get; set; }

        public ExtendedReadMessagesRequestDTO()
        {
            MessagesId = null!;
        }

        /// <summary>
        /// Перегрузка ToString()
        /// </summary>
        /// <returns>Строковое представление класса</returns>
        public override string ToString()
        {
            return $"Количество прочитанных сообщений: {MessagesId.Count}.";
        }
    }
}
