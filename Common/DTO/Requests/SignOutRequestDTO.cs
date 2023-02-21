using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Requests
{
    /// <summary>
    /// DTO: запрос на выход пользователя из аккаунта
    /// </summary>
    [ProtoContract]
    public class SignOutRequestDTO
    {
        /// <summary>
        /// Идетификатор
        /// </summary>
        [ProtoMember(1)]
        public int UserId { get; init; }

        /// <summary>
        /// Перегрузка ToString()
        /// </summary>
        /// <returns>Строковое представление класса</returns>
        public override string ToString()
        {
            return $"Id пользователя: {UserId}";
        }
    }
}
