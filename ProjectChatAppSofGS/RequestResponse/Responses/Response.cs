using Common.Network.Interfaces;
using Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.RequestResponse.Responses
{
    /// <summary>
    /// Базовый класс ответа на запрос
    /// </summary>
    public class Response : IResponse
    {
        /// <summary>
        /// Статус ответа
        /// </summary>
        public NetworkResponseStatus Status { get; set; }

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="status">Статус ответа</param>
        public Response(NetworkResponseStatus status)
        {
            Status = status;
        }
    }
}
