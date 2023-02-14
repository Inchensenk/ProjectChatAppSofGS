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
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string ConversationName { get; set; }

        public ConversationDTO()
        {
            ConversationName = null!;
        }

        public override string ToString() => $"Id: {Id} || ConversationName: {ConversationName} ";
    }
}
