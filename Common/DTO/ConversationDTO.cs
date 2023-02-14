using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    /// <summary>
    /// Data transfer object для диалогов
    /// </summary>
    [ProtoContract]
    public class ConversationDTO
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [ProtoMember(1)]
        public int Id { get; set; }

        /// <summary>
        /// Имя диалога
        /// </summary>
        [ProtoMember(2)]
        public string ConversationName { get; set; }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public ConversationDTO()
        {
            ConversationName = null!;
        }

        /// <summary>
        /// Переопределение метода ToString
        /// </summary>
        /// <returns>строка отоброжающая поля класса</returns>
        public override string ToString() => $"Id: {Id} || ConversationName: {ConversationName} ";
    }
}
