using AutoMapper;
using Common.Network;
using Common.Serialization;
using Server.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestResponse.RequestProcessing
{
    /// <summary>
    /// Статический конвертер сетевого сообщения для клиента в массив байт
    /// </summary>
    /// <typeparam name="TMessageData">Тип объекта, представляющего данные для сетевого сообщения</typeparam>
    /// <typeparam name="TMessageDataDTO">Тип DTO - представляющего данные для сетевого сообщения</typeparam>
    public static class NetworkMessageConverter<TMessageData, TMessageDataDTO>
    {
        /// <summary>
        /// Экземпляр маппера для DTO
        /// </summary>
        private static readonly IMapper _mapper = ServerMapper.GetInstance().CreateIMapper();

        /// <summary>
        /// Конвертирование
        /// </summary>
        /// <param name="messageData">Данные для сетевого сообщения</param>
        /// <param name="code">Код сетевого сообщения</param>
        /// <returns>Сетевое сообщение в виде массива байт</returns>
        public static byte[] Convert(TMessageData messageData, NetworkMessageCode code)
        {
            NetworkMessage networkMessage = ConvertToNetworkMessage(messageData, code);
            return SerializationHelper.Serialize(networkMessage);
        }

        /// <summary>
        /// Конвертирование данных в сетевое сообщение
        /// </summary>
        /// <param name="messageData">Данные для сетевого сообщения</param>
        /// <param name="code">Код сетевого сообщения</param>
        /// <returns>Сетевое сообщение</returns>
        private static NetworkMessage ConvertToNetworkMessage(TMessageData messageData, NetworkMessageCode code)
        {
            TMessageDataDTO dTO = _mapper.Map<TMessageDataDTO>(messageData);
            byte[] data = SerializationHelper.Serialize(dTO);
            return new NetworkMessage(data, code);
        }
    }
}
