using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Common.Network.Interfaces
{
    /// <summary>
    /// Интерфейс для подключения к сети и обмена данными по сети
    /// </summary>
    public interface INetworkProvider
    {
        /// <summary>
        /// Пересылка массива байт между клиентом и сервером
        /// </summary>
        public ITransmitterAsync Transmitter { get; }

        /// <summary>
        /// Сетевой поток осуществляющий передачу данных
        /// </summary>
        public NetworkStream? NetworkStream { get; }

        /// <summary>
        /// Асинхронная отправка массива байт по сетевому протоколу
        /// </summary>
        /// <param name="bytes">Исходящие данные</param>
        /// <returns></returns>
        public Task SendBytesAsync(byte[] bytes);

        /// <summary>
        /// Уведомляем об отключении от сети
        /// </summary>
        public void NotifyDisconnected();

        /// <summary>
        /// Закрываем соединение с сетью
        /// </summary>
        public void CloseConnection();
    }
}
