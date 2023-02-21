using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    /// <summary>
    /// Data transfer object для диалогов
    /// </summary>
    [ProtoContract]
    public class ConversationDTO
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [ProtoMember(1)]
        public int Id { get; set; }

        /// <summary>
        /// Список пользователей учавствующих в беседе
        /// </summary>
        [ProtoMember(2)]
        public List<UserDTO> UserListinc { get; set; }

        /// <summary>
        /// Список сообщений в диалоге
        /// </summary>
        [ProtoMember(3)]
        public List<MessageDTO> MessageListinc { get; set; }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public ConversationDTO()
        {
            UserListinc = new List<UserDTO>();
            MessageListinc = new List<MessageDTO>();
        }


    }
}
