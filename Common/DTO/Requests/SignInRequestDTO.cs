using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Requests
{
    /// <summary>
    /// DTO: запрос на вход в мессенджер
    /// </summary>
    [ProtoContract]
    public class SignInRequestDTO
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

        public SignInRequestDTO()
        {
            PhoneNumber = null!;
            Password = null!;
        }

        /// <summary>
        /// Перегрузка ToString()
        /// </summary>
        /// <returns>Строковое представление класса</returns>
        public override string ToString()
        {
            return $"Телефон: {PhoneNumber}.";
        }
    }
}
