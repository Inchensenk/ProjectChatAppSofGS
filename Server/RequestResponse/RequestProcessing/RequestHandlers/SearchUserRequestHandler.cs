using AutoMapper;
using Common.DTO.Requests;
using Common.DTO.Responses;
using Common.Network;
using Common.Serialization;
using Server.EFCore.DatabaseServices;
using Server.EFCore.Entities;
using Server.Net.Interfaces;
using Server.RequestResponse.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestResponse.RequestProcessing.RequestHandlers
{
    /// <summary>
    /// Обработчик запроса о поиске пользователя среди зарегистрировавшихся в мессенджере
    /// </summary>
    public class SearchUserRequestHandler : RequestHandler
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="mapper">Маппер</param>
        /// <param name="connectionController">Отвечает за соединение по сети с клиентами</param>
        public SearchUserRequestHandler(IMapper mapper, IConnectionController connectionController) : base(mapper, connectionController) { }

        /// <summary>
        /// Обработать найденный в базе данных список пользователей
        /// </summary>
        /// <param name="usersList">Список пользователей</param>
        /// <returns>Ответ на запрос о поиске пользователя</returns>
        private UserSearchResponse ProcessFoundUsersList(List<User> usersList)
        {
            if (usersList.Count > 0)
            {
                return new UserSearchResponse(usersList, NetworkResponseStatus.Successful);
            }
                
            return new UserSearchResponse(NetworkResponseStatus.Failed);
        }

        /// <summary>
        /// Обрабатывает сетевое сообщение
        /// </summary>
        /// <param name="dbService">Сервис для работы с базой данных</param>
        /// <param name="networkMessage">Сетевое сообщение</param>
        /// <param name="networkProvider">Сетевой провайдер</param>
        /// <returns>Ответ на сетевое сообщение в виде массива байт</returns>
        protected override byte[] OnProcess(DbService dbService, NetworkMessage networkMessage, IServerNetworkProvider networkProvider)
        {
            SearchRequestDTO searchRequestDto = SerializationHelper.Deserialize<SearchRequestDTO>(networkMessage.Data);

            List<User> usersList = dbService.FindListOfUsers(searchRequestDto);
            UserSearchResponse response = ProcessFoundUsersList(usersList);

            byte[] responseBytes = NetworkMessageConverter<UserSearchResponse, UserSearchResponseDTO>.Convert(response, NetworkMessageCode.SearchResponseCode);

            PrintReport(networkProvider.Id, networkMessage.Code, NetworkMessageCode.SearchResponseCode, searchRequestDto.ToString(), response.Status);

            return responseBytes;
        }

        /// <summary>
        /// Обрабатывает ошибку возникшую при обработке сетевого сообщения
        /// Ошибка скорее всего может бть связана с базой данных
        /// </summary>
        /// <param name="networkMessage">Сетевое сообщение</param>
        /// <param name="networkProvider">Сетевой провайдер</param>
        protected override void OnError(NetworkMessage networkMessage, IServerNetworkProvider networkProvider)
        {
            UserSearchResponse errorResponse = new UserSearchResponse(NetworkResponseStatus.FatalError);
            SendErrorResponse<UserSearchResponse, UserSearchResponseDTO>(networkProvider, errorResponse, NetworkMessageCode.SearchResponseCode);
        }
    }
}
