using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Requests
{
    /// <summary>
    /// DTO: Запрос на создание диалога
    /// </summary>
    [ProtoContract]
    public class CreateConversationRequestDTO
    {
        /// <summary>
        /// Список пользователей диалога
        /// </summary>
        [ProtoMember(1)]
        public List<int> UsersId { get; init; }

        /// <summary>
        /// Сообщения диалога
        /// </summary>
        public List<MessageDTO> Messages { get; init;}

        public CreateConversationRequestDTO()
        {
            UsersId = new List<int>();
            Messages = new List<MessageDTO>();
        }

        /// <summary>
        /// Перегрузка ToString()
        /// </summary>
        /// <returns>Строковое представление класса</returns>
        public override string ToString()
        {
            return $"Пользователь с Id: {UsersId.First()} хочет создать диалог с пользователем с Id: {UsersId.Last()}";
        }

    }
}
