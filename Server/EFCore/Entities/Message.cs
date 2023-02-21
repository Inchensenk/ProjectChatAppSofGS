using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.EFCore.Entities
{
    public class Message
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// Отправитель сообщения
        /// </summary>
        public User FromUser { get; set; }

        /// <summary>
        /// Идентификатор отправителя
        /// </summary>
        public int FromUserId { get; set; }

        /// <summary>
        /// Беседа которая хранит сообщение
        /// </summary>
        public Conversation Conversation { get; set; }

        /// <summary>
        /// Идентификатор беседы хранящей сообщение
        /// </summary>
        public int ConversationId { get; set; }

        /// <summary>
        /// Статус сообщения, который говорит прочитано сообщение или нет
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// Информация о времени и дате отправки сообщения
        /// </summary>
        public DateTime SendDateTime { get; set; }

        public Message()
        {
            Conversation = null!;
            MessageText= null!;
            FromUser = null!;
        }

    }
}
