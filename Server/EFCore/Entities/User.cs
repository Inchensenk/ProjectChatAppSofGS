using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.EFCore.Entities
{
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// Список бесед
        /// </summary>
        public List<Conversation> ConversationListinc { get; set; }

        /// <summary>
        /// Список отправленных сообщений
        /// </summary>
        public List<Message> SendMessagesListinc { get; set; }

        public User()
        {
            ConversationListinc = new List<Conversation>();
            SendMessagesListinc = new List<Message>();

            FirstName= null!;
            PhoneNumber= null!;
            Password = null!;
        }
    }
}
