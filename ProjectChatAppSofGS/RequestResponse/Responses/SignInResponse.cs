using Client.Models;
using Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.RequestResponse.Responses
{
    /// <summary>
    /// Ответ на запрос о входе в мессенджер
    /// </summary>
    public class SignInResponse : Response
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public User? User { get; init; }

        /// <summary>
        /// Список диалогов пользователя
        /// </summary>
        public List<Conversation>? ConversationListinc { get; init; }

        /// <summary>
        /// Контекст ошибки, если статус ответа неудачный
        /// </summary>
        public SignInFailContext Context { get; init; }

        /// <summary>
        /// Конструктор с парамаетрами
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="conversationListinc">Диалоги пользователя</param>
        /// <param name="status">Статус ответа</param>
        /// <param name="context">Констекст ошибки, в случае неудачного входа</param>
        public SignInResponse(User? user, List<Conversation>? conversationListinc, NetworkResponseStatus status, SignInFailContext context) : base(status)
        {
            User = user;
            ConversationListinc = conversationListinc;
            Context = context;
        }
    }
