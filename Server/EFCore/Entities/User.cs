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
        /*
        public int Id { get; set; }
        public string NickName { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Authorization? Authorization { get; set; }
        public List<Conversation> ConversationListinc { get; set; }

        public UserListinc()
        {
            ConversationListinc = new List<Conversation>();
            NickName = null!;
            PhoneNumber = null!;
            FirstName = null!;
            LastName = null!;
        }
        */

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
        }
    }
}
