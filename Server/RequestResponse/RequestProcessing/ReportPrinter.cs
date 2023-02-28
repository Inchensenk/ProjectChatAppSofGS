using Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestResponse.RequestProcessing
{
    /// <summary>
    /// Печать отчета о запросах на сервер и ответах с сервера
    /// </summary>
    public static class ReportPrinter
    {
        /// <summary>
        /// Печать отчета о запросе
        /// </summary>
        /// <param name="networkProviderId">Id сетевого провайдера</param>
        /// <param name="code">Код сетевого сообщения</param>
        /// <param name="info">Информация о запросе</param>
        public static void PrintRequestReport(int networkProviderId, NetworkMessageCode code, string info)
        {
            Console.WriteLine($"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Идентификатор клиента: {networkProviderId}. Запрос: код операции: {code}. " + info);
        }

        /// <summary>
        /// Печать отчета об ответе на запрос
        /// </summary>
        /// <param name="networkProviderId">Id сетевого провайдера</param>
        /// <param name="code">Код сетевого сообщения</param>
        /// <param name="status">Статус ответа</param>
        public static void PrintResponseReport(int networkProviderId, NetworkMessageCode code, NetworkResponseStatus status)
        {
            Console.WriteLine($"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Идентификатор клиента: {networkProviderId}. Ответ: код операции: {code}. Статус ответа: {status}.");
        }
    }
}
