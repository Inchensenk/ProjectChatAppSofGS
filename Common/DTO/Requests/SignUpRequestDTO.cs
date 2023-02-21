using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.DTO.Requests
{
    [ProtoContract]
    public class SignUpRequestDTO
    {
        /// <summary>
        /// Номер телефона
        /// </summary>
        [ProtoMember(1)]
        public string PhoneNumber { get; init; }

        /// <summary>
        /// Пароль
        /// </summary>
        [ProtoMember(2)]
        public string Password { get; init; }

        /// <summary>
        /// Имя
        /// </summary>
        [ProtoMember(3)]
        public string FirstName { get; init; }

        public SignUpRequestDTO()
        {
            FirstName = null!;
            Password = null!;
            PhoneNumber = null!;
        }

        /// <summary>
        /// Переопределение метода ToString
        /// </summary>
        /// <returns>Строковое представление класса</returns>
        public override string ToString()
        {
            return $"Телефон: {PhoneNumber}. Имя: {FirstName}";
        }
    }
}
