using Common.Network;
using Server.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestResponse.Responses
{
    /// <summary>
    /// Ответ на запрос о входе в аккаунт 
    /// </summary>
    public class SignInResponse : Response
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Список бесед пользователя
        /// </summary>
        public List<Conversation>? ConversationListinc { get; set; }

        /// <summary>
        /// Контекст ошибки
        /// </summary>
        public SignInFailContext Context { get; init; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="status">статус ответа</param>
        public SignInResponse(NetworkResponseStatus status) : base(status)
        {
            User= null;
            ConversationListinc= null;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="status">Статус ответа</param>
        /// <param name="сontext">Контекст ошибки, если статус ответа неудачный</param>
        public SignInResponse(NetworkResponseStatus status, SignInFailContext сontext) : base(status)
        {
            Context = сontext;
            ConversationListinc = new List<Conversation>();
        }


        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="conversationListinc">Список диалогов пользователя</param>
        /// <param name="status">Статус ответа</param>
        public SignInResponse(User user, List<Conversation> conversationListinc, NetworkResponseStatus status) : base(status)
        {
            User = user;
            ConversationListinc = conversationListinc;
        }
    }
}
