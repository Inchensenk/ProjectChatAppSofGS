using Common.Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Network
{
    /// <summary>
    /// Пересылка байт между клиентом и сервером
    /// </summary>
    public class Transmitter : ITransmitterAsync
    {
        /// <summary>
        /// Провайдер для подключения к сети
        /// </summary>
        public INetworkProvider NetworkProvider { get; private set; }

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="networkProvider">Сетевой провайдер</param>
        public Transmitter(INetworkProvider networkProvider)
        {
            NetworkProvider = networkProvider;
        }

        /// <summary>
        /// Получение сообщения
        /// </summary>
        public async Task<byte[]> ReceiveBytesAsync()
        {
            byte[] lengthBuffer = new byte[4];
            List<byte> bytesList = new List<byte>();
            int bytes = 0;

            bytes = await NetworkProvider.NetworkStream.ReadAsync(lengthBuffer, 0, lengthBuffer.Length);

            if (bytes == 0)
                throw new IOException();

            int length = BitConverter.ToInt32(lengthBuffer, 0);

            byte[] data = new byte[length];

            do
            {
                bytes = await NetworkProvider.NetworkStream.ReadAsync(data, 0, data.Length);

                for (int i = 0; i < bytes; ++i)
                {
                    bytesList.Add(data[i]);
                }

            } while (bytesList.Count < length);

            data = bytesList.ToArray();

            return data;
        }

        /// <summary>
        /// Асинхронная отправка сетевого сообщения серверу
        /// </summary>
        /// <param name="networkMessage">Сетевое сообщение в виде массива байт</param>
        public async Task SendNetworkMessageAsync(byte[] networkMessage)
        {
            Int32 bytesNumber = networkMessage.Length;

            byte[] length = BitConverter.GetBytes(bytesNumber);

            byte[] messageWithLength = new byte[networkMessage.Length + length.Length];

            length.CopyTo(messageWithLength, 0);
            networkMessage.CopyTo(messageWithLength, length.Length);

            await NetworkProvider.NetworkStream.WriteAsync(messageWithLength, 0, messageWithLength.Length);
        }
    }
}
