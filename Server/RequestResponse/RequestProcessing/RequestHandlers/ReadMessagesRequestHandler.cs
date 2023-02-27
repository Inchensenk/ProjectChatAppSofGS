using AutoMapper;
using Common.DTO.Requests;
using Common.DTO.Responses;
using Common.Network;
using Common.Serialization;
using Server.EFCore.DatabaseServices;
using Server.Net.Interfaces;
using Server.RequestResponse.Request;
using Server.RequestResponse.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestResponse.RequestProcessing.RequestHandlers
{
    /// <summary>
    /// Обработчик запроса о прочтении сообщения
    /// </summary>
    public class ReadMessagesRequestHandler : RequestHandler
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="mapper">Маппер</param>
        /// <param name="connectionController">Отвечает за соединение по сети с клиентами</param>
        public ReadMessagesRequestHandler(IMapper mapper, IConnectionController connectionController) : base(mapper, connectionController) { }


        /// <summary>
        /// Транслировать запрос о прочтении сообщений всем сетевым провайдерам пользователя, кроме того, с которого пришел запрос о прочтении
        /// </summary>
        /// <param name="readRequest">Запрос о прочтении сообщений</param>
        private void BroadcastReadMessagesRequest(ExtendedReadMessagesRequestDTO readRequest, int networkProviderId)
        {
            ReadMessagesRequest readMessagesRequest = new ReadMessagesRequest(readRequest.MessagesId, readRequest.ConversationId);
            byte[] requestBytes = NetworkMessageConverter<ReadMessagesRequest, ReadMessagesRequestDTO>.Convert(readMessagesRequest, NetworkMessageCode.ReadMessagesRequestCode);
            _conectionController.BroadcastToSenderAsync(requestBytes, readRequest.UserId, networkProviderId);
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
            ExtendedReadMessagesRequestDTO messagesRequestDTO = SerializationHelper.Deserialize<ExtendedReadMessagesRequestDTO>(networkMessage.Data);

            dbService.ReadMessages(messagesRequestDTO);

            Response response = new Response(NetworkResponseStatus.Successful);

            BroadcastReadMessagesRequest(messagesRequestDTO, networkProvider.Id);

            byte[] byteResponse = NetworkMessageConverter<Response, ResponseDTO>.Convert(response, NetworkMessageCode.ReadMessagesResponseCode);

            PrintReport(networkProvider.Id, networkMessage.Code, NetworkMessageCode.ReadMessagesResponseCode, messagesRequestDTO.ToString(), response.Status);

            return byteResponse;
        }

    }
}
