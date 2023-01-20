using ProtoBuf;

namespace DTO
{
    [ProtoContract]
    public class AuthDTO
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Login { get; set; } = null!;

        [ProtoMember(3)]
        public string Password { get; set; } = null!;

        public override string ToString() => $"Id: {Id} || Login: {Login} || Password: {Password}";

    }
}