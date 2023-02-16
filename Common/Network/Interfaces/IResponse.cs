using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Network.Interfaces
{
    /// <summary>
    /// Интерфейс для ответа на запрос
    /// </summary>
    public interface IResponse
    {

        /// <summary>
        /// Статус ответа
        /// </summary>
        public NetworkResponseStatus Status { get; set; }
    }
}
