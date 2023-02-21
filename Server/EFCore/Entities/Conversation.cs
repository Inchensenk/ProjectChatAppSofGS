using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.EFCore.Entities
{
    public class Conversation
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Список пользователей
        /// </summary>
        public List<User> UserListinc { get; set; }

        /// <summary>
        /// Список сообщений
        /// </summary>
        public List<Message> MessageListinc { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Conversation()
        {
            UserListinc = new List<User>();
            MessageListinc = new List<Message>();
        }
    }
}
