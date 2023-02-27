using Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestResponse.Responses
{
    /// <summary>
    /// Ответ на запрос об отправке сообщения для пользователя, который его отправил.
    /// Подтверждение отправки сообщения
    /// </summary>
    public class SendMessageResponse : Response
    {
        /// <summary>
        /// Идентификатор отправленного сообщения
        /// </summary>
        public int MessageId { get; init; }

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="status">Статус ответа</param>
        public SendMessageResponse(NetworkResponseStatus status): base(status) { }

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="id">Идентификатор сообщения</param>
        /// <param name="status">Статус ответа</param
        public SendMessageResponse(int id, NetworkResponseStatus status) : base(status) 
        { 
            MessageId= id;
        }
    }
}
