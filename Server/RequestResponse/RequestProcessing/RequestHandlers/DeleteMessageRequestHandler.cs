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
    public class DeleteMessageRequestHandler : RequestHandler
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="mapper">Маппер</param>
        /// <param name="connectionController">Контроллер отвечающий за соединение по сети с клиентами</param>
        public DeleteMessageRequestHandler(IMapper mapper, IConnectionController connectionController) : base(mapper, connectionController) { }

        /// <summary>
        /// Обработать найденное в базе данных сообщение
        /// </summary>
        /// <param name="dbService">Сервис для работы с базой данных</param>
        /// <param name="message">Сообщение найденное в базе данных</param>
        /// <param name="userId">Id пользователя</param>
        /// <param name="networkProviderId">Id сетевого провайдера</param>
        /// <returns>Ответ на запрос об удалении сообщения</returns>
        private Response ProcessFoundMessage(DbService dbService, Message? message, int userId, int networkProviderId)
        {
            if (message != null)
            {
                int interlocutorId = dbService.GetInterlocutorId(message.ConversationId, userId);
                dbService.DeleteMessage(message);
                DeleteMessageRequest deleteMessageRequest = new DeleteMessageRequest(message.Id, message.ConversationId);
                byte[] requestBytes = NetworkMessageConverter<DeleteMessageRequest, DeleteMessageRequestDTO>.Convert(deleteMessageRequest, NetworkMessageCode.DeleteMessageRequestCode);
                _conectionController.BroadcastToSenderAsync(requestBytes, userId, networkProviderId);
                _conectionController.BroadcastToInterlocutorAsync(requestBytes, interlocutorId);

                return new Response(NetworkResponseStatus.Successful);
            }
            return new Response(NetworkResponseStatus.Failed);
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
            ExtendedDeleteMessageRequestDTO deleteMessageRequestDTO = SerializationHelper.Deserialize<ExtendedDeleteMessageRequestDTO>(networkMessage.Data);
            Message? message = dbService.FindMessage(deleteMessageRequestDTO);
            Response response = ProcessFoundMessage(dbService, message, deleteMessageRequestDTO.UserId, networkProvider.Id);

            byte[] responseBytes = NetworkMessageConverter<Response, ResponseDTO>.Convert(response, NetworkMessageCode.DeleteMessageResponseCode);
            PrintReport(networkProvider.Id, networkMessage.Code, NetworkMessageCode.DeleteMessageResponseCode, deleteMessageRequestDTO.ToString(), response.Status);

            return responseBytes;
        }
    }
}
