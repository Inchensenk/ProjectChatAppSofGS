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
    /// Результат поиска пользователей в приложении
    /// </summary>
    public class UserSearchResponse : Response
    {
        /// <summary>
        /// Пользователи удовлетворяющие поиску
        /// </summary>
        public List<User> RelevantUsers { get; set; }

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="status">Статус ответа</param>
        public UserSearchResponse(NetworkResponseStatus status) : base(status)
        {
            RelevantUsers = new List<User>();
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="relevantUsers">Пользователи удовлетворяющие поиску</param>
        /// <param name="status">Статус ответа</param>
        public UserSearchResponse(List<User> relevantUsers, NetworkResponseStatus status) : base(status)
        {
            RelevantUsers = relevantUsers;
        }
    }
}
