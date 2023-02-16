using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Net.Interfaces
{
    /// <summary>
    /// Интерфейс, который управляет обработкой запросов отпрвленных клиентами
    /// </summary>
    public interface IRequestController
    {
        /// <summary>
        /// Обрабатывает массив байтов переданных по сети
        /// </summary>
        /// <param name="data">Полученный массив байтов</param>
        /// <param name="networkProviderId">Идентификатор сетевого провайдера</param>
        /// <returns></returns>
        public byte[] ProcessRequest(byte[] data, IServerNetworkProvider networkProviderId);
    }
}
