using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.RequestResponse.Requests
{
    /// <summary>
    /// Запрос на выход из приложения
    /// </summary>
    public class SignOutRequest
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public int UserId { get; init; }

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        public SignOutRequest(int userId)
        {
            UserId = userId;
        }
    }
}
