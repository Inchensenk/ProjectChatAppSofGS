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
    /// Обработчик запроса о регистрации в мессенджере
    /// </summary>
    public class SignUpRequestHandler : RequestHandler
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="mapper">Маппер</param>
        /// <param name="connectionController">Отвечает за соединение по сети с клиентами</param>
        public SignUpRequestHandler(IMapper mapper, IConnectionController connectionController) : base(mapper, connectionController) {  }


        /// <summary>
        /// Обработать добавление пользователя в базу данных
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="networkProviderId">Id сетевого провайдера</param>
        /// <returns>Ответ на запрос о регистрации пользователя</returns>
        private SignUpResponse ProcessAddingUserInDb(User? user, int networkProviderId)
        {
            if (user != null)
            {
                _conectionController.AddNewSession(user.Id, networkProviderId);

                return new SignUpResponse(user.Id, NetworkResponseStatus.Successful);
            }

            return new SignUpResponse(NetworkResponseStatus.Failed);
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
            SignUpRequestDTO signUpRequestDto = SerializationHelper.Deserialize<SignUpRequestDTO>(networkMessage.Data);

            User? user = dbService.AddNewUser(signUpRequestDto);

            SignUpResponse signUpResponse = ProcessAddingUserInDb(user, networkProvider.Id);

            byte[] responseBytes = NetworkMessageConverter<SignUpResponse, SignUpResponseDTO>.Convert(signUpResponse, NetworkMessageCode.SignUpResponseCode);

            PrintReport(networkProvider.Id, networkMessage.Code, NetworkMessageCode.SignUpResponseCode, signUpRequestDto.ToString(), signUpResponse.Status);

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
            SignUpResponse errorResponse = new SignUpResponse(NetworkResponseStatus.FatalError);
            SendErrorResponse<SignUpResponse, SignUpResponseDTO>(networkProvider, errorResponse, NetworkMessageCode.SignUpResponseCode);
        }
    }
}
