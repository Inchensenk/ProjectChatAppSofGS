using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Requests
{
    /// <summary>
    /// DTO: запрос на поиск пользователя среди зарегестрированных
    /// </summary>
    [ProtoContract]
    public class SearchRequestDTO
    {
        /// <summary>
        /// Имя
        /// </summary>
        [ProtoMember(1)]
        public string FirstName { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        [ProtoMember(2)]
        public string PhoneNumber{ get; set; }

        public SearchRequestDTO()
        {
            FirstName = null!;
            PhoneNumber = null!;
        }


        /// <summary>
        /// Перегрузка ToString()
        /// </summary>
        /// <returns>Строковое представление класса</returns>
        public override string ToString()
        {
            if (String.IsNullOrEmpty(FirstName))
                return $"Телефон: {PhoneNumber}.";

            else if (String.IsNullOrEmpty(PhoneNumber))
                return $"Имя: {FirstName}.";

            return $"Имя: {FirstName}. Телефон: {PhoneNumber}.";
        }
    }
}
