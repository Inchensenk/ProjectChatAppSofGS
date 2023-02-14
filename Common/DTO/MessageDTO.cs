using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    /// <summary>
    /// Data transfer object сообщений
    /// </summary>
    [ProtoContract]
    public class MessageDTO
    {

        /// <summary>
        /// Идентификатор
        /// </summary>
        [ProtoMember(1)]
        public int Id { get; init; }

        /// <summary>
        /// Номер отправителя сообщения
        /// </summary>
        [ProtoMember(2)]
        public string FromNumber { get; init; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        [ProtoMember(3)]
        public string MessageText { get; init; }

        /// <summary>
        /// Время отправки сообщения
        /// </summary>
        [ProtoMember(4)]
        public DateTime SendDateTime { get; init; }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public MessageDTO()
        {
            FromNumber = null!;
            MessageText = null!;
        }

        /// <summary>
        /// Переопределение метода ToString
        /// </summary>
        /// <returns>строка отоброжающая поля класса</returns>
        public override string ToString() => $"Id: {Id} || FromNumber: {FromNumber} || MessageText: {MessageText} || SendDateTime: {SendDateTime}";
    }
}
