using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    /// <summary>
    /// DTO: пользователь
    /// </summary>
    [ProtoContract]
    public class UserDTO
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [ProtoMember(1)]
        public int Id { get; init; }

        /// <summary>
        /// Имя
        /// </summary>
        [ProtoMember(2)]
        public string FirstName { get; init; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        [ProtoMember(3)]
        public string PhoneNumber { get; init; }

        /// <summary>
        /// Пароль
        /// </summary>
        [ProtoMember(4)]
        public string Password { get; init; }

        public UserDTO()
        {
            FirstName = null!;
            PhoneNumber = null!;
            Password = null!;
        }

        /// <summary>
        /// Переопределение метода ToString
        /// </summary>
        /// <returns>Строковое представление класса</returns>
        public override string ToString()
        {
            return $"Id: {Id}. PhoneNumber: {PhoneNumber}. Password: {Password}.";
        }
}
}
