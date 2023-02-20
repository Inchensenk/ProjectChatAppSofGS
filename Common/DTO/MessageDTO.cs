using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    /// <summary>
    /// Data transfer object сообщений
    /// </summary>
    [ProtoContract]
    public class MessageDTO
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [ProtoMember(1)]
        public int Id { get; init; }

        /// <summary>
        /// Отправитель сообщения
        /// </summary>
        [ProtoMember(2)]
        public UserDTO FromUser { get; init; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        [ProtoMember(3)]
        public string MessageText { get; init; }

        /// <summary>
        /// Время отправки сообщения
        /// </summary>
        [ProtoMember(4)]
        public DateTime SendDateTime { get; init; }

        /// <summary>
        /// Сообщение прочитано?
        /// </summary>
        [ProtoMember(5)]
        public bool IsRead { get; init; }

        public MessageDTO()
        {
            FromUser = null!;
            MessageText = null!;
        }

    }
}
