using Common.Network;
using Common.Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestResponse.Responses
{
    /// <summary>
    /// Ответ на запрос
    /// </summary>
    public class Response : IResponse
    {
        /// <summary>
        /// Статус ответа
        /// </summary>
        public NetworkResponseStatus Status { get; set; }


        public Response(NetworkResponseStatus status)
        {
            Status = status;
        }

        public Response()
        {

        }
    }
}
