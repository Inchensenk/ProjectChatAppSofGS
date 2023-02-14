using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    [ProtoContract]
    public class MessageDTO
    {
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(1)]
        public int Id { get; init; }

        [ProtoMember(2)]
        public string FromNumber { get; set; } = null!;

        [ProtoMember(3)]
        public string MessageText { get; set; } = null!;

        [ProtoMember(4)]
        public DateTime SendDateTime { get; set; }
        public override string ToString() => $"Id: {Id} || FromNumber: {FromNumber} || MessageText: {MessageText} || SendDateTime: {SendDateTime}";
    }
}
