using AutoMapper;
using Common.DTO.Requests;
using Common.DTO.Responses;
using Common.Network;
using Common.Serialization;
using Server.EFCore.DatabaseServices;
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
    /// Обработчик запроса по выходу пользователя из мессенджера
    /// </summary>
    public class SignOutRequestHandler : RequestHandler
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="mapper">Маппер</param>
        /// <param name="connectionController">Отвечает за соединение по сети с клиентами</param>
        public SignOutRequestHandler(IMapper mapper, IConnectionController connectionController) : base(mapper, connectionController) {  }

        /// <summary>
        /// Обрабатывает сетевое сообщение
        /// </summary>
        /// <param name="dbService">Сервис для работы с базой данных</param>
        /// <param name="networkMessage">Сетевое сообщение</param>
        /// <param name="networkProvider">Сетевой провайдер</param>
        /// <returns>Ответ на сетевое сообщение в виде массива байт</returns>
        protected override byte[] OnProcess(DbService dbService, NetworkMessage networkMessage, IServerNetworkProvider networkProvider)
        {
            SignOutRequestDTO signOutRequestDTO = SerializationHelper.Deserialize<SignOutRequestDTO>(networkMessage.Data);

            _conectionController.DisconnectUser(signOutRequestDTO.UserId, networkProvider.Id);
            Response response = new Response(NetworkResponseStatus.Successful);

            byte[] responseBytes = NetworkMessageConverter<Response, ResponseDTO>.Convert(response, NetworkMessageCode.SignOutResponseCode);

            PrintReport(networkProvider.Id, networkMessage.Code, NetworkMessageCode.SignOutResponseCode, signOutRequestDTO.ToString(), response.Status);

            return responseBytes;
        }
    }
}
