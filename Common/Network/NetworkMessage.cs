using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Network
{
    /// <summary>
    /// Сетевое сообщение, отправляется от клиента к серверу и обратно
    /// </summary>
    [ProtoContract]
    public class NetworkMessage
    {
        /// <summary>
        /// Код сетевого сообщения
        /// </summary>
        [ProtoMember(1)]
        public NetworkMessageCode Code { get; init; }

        /// <summary>
        /// Данные, хранящиеся в сетевом сообщении
        /// </summary>
        [ProtoMember(2)]
        public byte[]? Data { get; init; }

        /// <summary>
        /// Для работы ProtoBuf нужен конструктор по умолчанию
        /// </summary>
        public NetworkMessage() {  }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="data">Данные, хранящиеся в сетевом сообщении</param>
        /// <param name="code">Код сетевого сообщения</param>
        public NetworkMessage(byte[]? data, NetworkMessageCode code)
        {
            Code = code;
            Data = data;
        }
    }
}
