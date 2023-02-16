using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Network.Interfaces
{
    /// <summary>
    /// Интерфейс для асинхронной пекресылки массива байт по сети
    /// </summary>
    public interface ITransmitterAsync
    {
        /// <summary>
        /// Отправка сетевого сообщения серверу
        /// </summary>
        /// <param name="networkMessageBytes">Сетевое сообщение в виде массива байт</param>
        /// <returns></returns>
        public Task SendNetworkMessageAsync(byte[] networkMessageBytes);

        /// <summary>
        /// Получение массива байт из потока
        /// </summary>
        /// <returns>Масив байт</returns>
        public Task<byte[]> ReceiveBytesAsync();
    }
}
