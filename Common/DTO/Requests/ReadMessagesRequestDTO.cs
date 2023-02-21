using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Requests
{
    /// <summary>
    /// DTO: запрос на прочтение сообщения от сервера клиенту
    /// </summary>
    [ProtoContract]
    public class ReadMessagesRequestDTO
    {
        /// <summary>
        /// Список идентификаторов прочитанных сообщений
        /// </summary>
        [ProtoMember(1)]
        public List<int> MessagesId { get; init; }

        /// <summary>
        /// Идетификатор диалога, которому принадлежат сообщения
        /// </summary>
        [ProtoMember(2)]
        public int ConversationId { get; init; }
        public ReadMessagesRequestDTO()
        {
            MessagesId = null!;
        }
    }
}
