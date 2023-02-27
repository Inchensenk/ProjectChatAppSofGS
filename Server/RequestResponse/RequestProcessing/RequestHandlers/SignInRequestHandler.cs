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
    /// Обработчик запроса о входе в мессенджер
    /// </summary>
    public class SignInRequestHandler : RequestHandler
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="mapper">Маппер</param>
        /// <param name="connectionController">Отвечает за соединение по сети с клиентами</param>
        public SignInRequestHandler(IMapper mapper, IConnectionController connectionController) : base(mapper, connectionController) { }


        /// <summary>
        /// Обработать найденного в базе данных пользователя
        /// </summary>
        /// <param name="dbService">Сервис для работы с базой данных</param>
        /// <param name="user">Найденный в базе данных пользователь</param>
        /// <param name="signInRequestDto">DTO - запрос на вход в мессенджер</param>
        /// <param name="networkProviderId">Id сетевого провайдера</param>
        /// <returns>Ответ на запрос о входе пользователя</returns>
        private SignInResponse ProcessFoundUser(DbService dbService, User? user, SignInRequestDTO signInRequestDto, int networkProviderId)
        {
            if (user != null)
            {
                if (user.Password == signInRequestDto.Password)
                {
                    List<Conversation> conversations = dbService.FindConversationsByUser(user);
                    _conectionController.AddNewSession(user.Id, networkProviderId);

                    return new SignInResponse(user, conversations, NetworkResponseStatus.Successful);
                }

                return new SignInResponse(NetworkResponseStatus.Failed, SignInFailContext.Password);
            }

            return new SignInResponse(NetworkResponseStatus.Failed, SignInFailContext.PhoneNumber);
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
            SignInRequestDTO signInRequestDTO = SerializationHelper.Deserialize<SignInRequestDTO>(networkMessage.Data);

            User? user = dbService.FindUserByPhoneNumber(signInRequestDTO.PhoneNumber);

            SignInResponse signInResponse = ProcessFoundUser(dbService, user, signInRequestDTO, networkProvider.Id);

            byte[] responseBytes = NetworkMessageConverter<SignInResponse, SignInResponseDTO>.Convert(signInResponse, NetworkMessageCode.SignInResponseCode);

            PrintReport(networkProvider.Id, networkMessage.Code, NetworkMessageCode.SignInResponseCode, signInRequestDTO.ToString(), signInResponse.Status);

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
            SignInResponse signInResponse = new SignInResponse(NetworkResponseStatus.FatalError);
            SendErrorResponse<SignInResponse, SignInResponseDTO>(networkProvider, signInResponse, NetworkMessageCode.SignUpResponseCode);
        }
    }
}
