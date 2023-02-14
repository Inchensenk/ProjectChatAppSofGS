using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    /// <summary>
    /// Data transfer object пользователя
    /// </summary>
    [ProtoContract]
    public class UserDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [ProtoMember(1)]/*Атрибут - для сереализации/десереализации, задает интовый идентификатор для свойства*/
        public int Id { get; init; }

        /// <summary>
        /// Ник
        /// </summary>
        [ProtoMember(2)]
        public string NickName { get; private set; }

        /// <summary>
        /// Телефон
        /// </summary>
        [ProtoMember(3)]
        public string PhoneNumber { get; private set; }

        /// <summary>
        /// Имя
        /// </summary>
        [ProtoMember(4)]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [ProtoMember(5)]
        public string LastName { get; set; }


        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public UserDto()
        {
            NickName = null!;
            PhoneNumber = null!;
            FirstName = null!;
            LastName = null!;
        }

        /// <summary>
        /// Переопределение метода ToString
        /// </summary>
        /// <returns>строка отоброжающая поля класса</returns>
        public override string ToString() => $"Id: {Id} || NickName: {NickName} || PhoneNumber: {PhoneNumber} || FirstName: {FirstName} || LastName: {LastName}";
    }
}
