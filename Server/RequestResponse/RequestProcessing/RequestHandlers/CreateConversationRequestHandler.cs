using AutoMapper;
using Common.DTO;
using Common.DTO.Requests;
using Common.DTO.Responses;
using Common.Network;
using Common.Serialization;
using Server.EFCore.DatabaseServices;
using Server.EFCore.Entities;
using Server.Net;
using Server.Net.Interfaces;
using Server.RequestResponse.Responses;

namespace Server.RequestResponse.RequestProcessing.RequestHandlers
{
    /// <summary>
    /// Обработчик запроса по созданию диалога
    /// </summary>
    public class CreateConversationRequestHandler : RequestHandler
    {
        /// <summary>
        ///  Обработчик запроса по созданию диалога
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="connectionController"></param>
        public CreateConversationRequestHandler(IMapper mapper, IConnectionController connectionController) : base(mapper, connectionController) { }

        protected override void OnError(NetworkMessage networkMessage, IServerNetworkProvider networkProvider)
        {
            CreateConversationResponse errorResponse = new CreateConversationResponse(NetworkResponseStatus.FatalError);
            SendErrorResponse<CreateConversationResponse, CreateConversationResponseDTO>(networkProvider, errorResponse, NetworkMessageCode.CreateConversationResponseCode);
        }



        private void BroadcastCreateConversationRecvests(Conversation conversation, int networkProviderId)
        {
            int senderId = conversation.MessageListinc.First().FromUserId;
            int recipientId = conversation.UserListinc.First(user => user.Id != senderId).Id;

            byte[] createConversationMessageBytes = NetworkMessageConverter<Conversation, ConversationDTO>.Convert(conversation, NetworkMessageCode.CreateConversationRequestCode);

            _conectionController.BroadcastToSenderAsync(createConversationMessageBytes, senderId, networkProviderId);
            _conectionController.BroadcastToInterlocutorAsync(createConversationMessageBytes, recipientId);
        }


        protected override byte[] OnProcess(DbService dbService, NetworkMessage networkMessage, IServerNetworkProvider networkProvider)
        {
            CreateConversationRequestDTO createConversationRequestDTO = SerializationHelper.Deserialize<CreateConversationRequestDTO>(networkMessage.Data);

            Conversation conversation = dbService.CreateConversation(createConversationRequestDTO);

            CreateConversationResponse response = _mapper.Map<CreateConversationResponse>(conversation);

            byte[] responseBytes = NetworkMessageConverter<CreateConversationResponse, CreateConversationResponseDTO>.Convert(response, NetworkMessageCode.CreateConversationResponseCode);

            BroadcastCreateConversationRecvests(conversation, networkProvider.Id);

            PrintReport(networkProvider.Id, networkMessage.Code, NetworkMessageCode.CreateConversationResponseCode, createConversationRequestDTO.ToString(), response.Status);
            
            return responseBytes;
        }


    }
}
