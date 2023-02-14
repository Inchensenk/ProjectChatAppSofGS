using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    /// <summary>
    /// Data transfer object авторизации
    /// </summary>
    [ProtoContract]
    public class AuthorizationDTO
    {

        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Login { get; set; }

        [ProtoMember(3)]
        public string Password { get; set; } 

        public AuthorizationDTO()
        {
            Login = null!;
            Password = null!;
        }

        public override string ToString() => $"Id: {Id} || Login: {Login} || Password: {Password}";
    }
}
