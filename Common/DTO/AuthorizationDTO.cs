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
        /// <summary>
        /// Идентификатор
        /// </summary>
        [ProtoMember(1)]
        public int Id { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        [ProtoMember(2)]
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [ProtoMember(3)]
        public string Password { get; set; } 

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public AuthorizationDTO()
        {
            Login = null!;
            Password = null!;
        }

        /// <summary>
        /// Переопределение метода ToString
        /// </summary>
        /// <returns>строка отоброжающая поля класса</returns>
        public override string ToString() => $"Id: {Id} || Login: {Login} || Password: {Password}";
    }
}
