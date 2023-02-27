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
    /// Обработчик запроса об удалении диалога
    /// </summary>
    public class DeleteConversationRequestHandler : RequestHandler
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="mapper">Маппер</param>
        /// <param name="connectionController">Отвечает за соединение по сети с клиентами</param>
        public DeleteConversationRequestHandler(IMapper mapper, IConnectionController connectionController) : base(mapper, connectionController) { }

        /// <summary>
        /// Обработка найденного в БД диалога
        /// </summary>
        /// <param name="dbService">Сервис для работы с базой данных</param>
        /// <param name="conversation">Диалог найденный в базе данных</param>
        /// <param name="networkProviderId">Id сетевого провайдера</param>
        /// <param name="userId">Id пользователя</param>
        /// <returns>Ответ на запрос об удалении диалога</returns>
        private Response ProcessFoundConversation(DbService dbService, Conversation? conversation, int networkProviderId, int userId)
        {
            if (conversation != null)
            {
                int interlocutorId = dbService.GetInterlocutorId(conversation.Id, userId);
                dbService.DeleteConversation(conversation);
                DeleteConversationRequest deleteConversationRequest = new DeleteConversationRequest(conversation.Id);
                byte[] requestBytes = NetworkMessageConverter<DeleteConversationRequest, DeleteConversationRequestDTO>.Convert(deleteConversationRequest, NetworkMessageCode.DeleteConversationRequestCode);
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
            ExtendedDeleteConversationRequestDTO deleteConversationRequestDTO = SerializationHelper.Deserialize<ExtendedDeleteConversationRequestDTO>(networkMessage.Data);
            Conversation? conversation = dbService.FindConversation(deleteConversationRequestDTO);
            Response response = ProcessFoundConversation(dbService, conversation, networkProvider.Id, deleteConversationRequestDTO.UserId);
            byte[] responseBytes = NetworkMessageConverter<Response, ResponseDTO>.Convert(response, NetworkMessageCode.DeleteConversationResponseCode);
            PrintReport(networkProvider.Id, networkMessage.Code, NetworkMessageCode.DeleteConversationResponseCode, deleteConversationRequestDTO.ToString(), response.Status);
            return responseBytes;
        }
    }
}
