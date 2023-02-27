using AutoMapper;
using Common.DTO.Requests;
using Common.DTO.Responses;
using Common.Network;
using Common.Serialization;
using Server.EFCore.DatabaseServices;
using Server.EFCore.Entities;
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
    /// Обработчик запроса об отправке пользователем сообщения
    /// </summary>
    public class SendMessageRequestHandler : RequestHandler
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="mapper">Маппер</param>
        /// <param name="connectionController">Отвечает за соединение по сети с клиентами</param>
        public SendMessageRequestHandler(IMapper mapper, IConnectionController connectionController) : base(mapper, connectionController) {  }

        /// <summary>
        /// Транслировать запрос об отправке сообщения
        /// </summary>
        /// <param name="dbService">Сервис для работы с базой данных</param>
        /// <param name="message">Сообщение</param>
        /// <param name="networkProviderId">Id сетевого провайдера</param>
        private void BroadcastSendMessageRequest(DbService dbService, Message message, int networkProviderId)
        {
            int recipientUserId = dbService.GetRecipientUserId(message);
            SendMessageRequest sendMessageRequest = new SendMessageRequest(message, message.ConversationId);

            byte[] requestBytes = NetworkMessageConverter<SendMessageRequest, SendMessageRequestDTO>.Convert(sendMessageRequest, NetworkMessageCode.SendMessageRequestCode);

            _conectionController.BroadcastToSenderAsync(requestBytes, message.FromUserId, networkProviderId);
            _conectionController.BroadcastToInterlocutorAsync(requestBytes, recipientUserId);
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
            SendMessageRequestDTO sendMessageRequestDto = SerializationHelper.Deserialize<SendMessageRequestDTO>(networkMessage.Data);

            Message message = dbService.AddMessage(sendMessageRequestDto);
            SendMessageResponse response = new SendMessageResponse(message.Id, NetworkResponseStatus.Successful);
            BroadcastSendMessageRequest(dbService, message, networkProvider.Id);

            byte[] responseBytes = NetworkMessageConverter<SendMessageResponse, SendMessageResponseDTO>.Convert(response, NetworkMessageCode.SendMessageResponseCode);

            PrintReport(networkProvider.Id, networkMessage.Code, NetworkMessageCode.SendMessageResponseCode, sendMessageRequestDto.ToString(), response.Status);

            return responseBytes;
        }

        /// <summary>
        /// Обрабатывает ошибку возникшую при обработке сетевого сообщения
        /// Ошибка скорее всего может быть связана с базой данных
        /// </summary>
        /// <param name="networkMessage">Сетевое сообщение</param>
        /// <param name="networkProvider">Сетевой провайдер</param>
        protected override void OnError(NetworkMessage networkMessage, IServerNetworkProvider networkProvider)
        {
            SendMessageResponse errorResponse = new SendMessageResponse(NetworkResponseStatus.FatalError);
            SendErrorResponse<SendMessageResponse, SendMessageResponseDTO>(networkProvider, errorResponse, NetworkMessageCode.SendMessageResponseCode);
        }
    }
}
