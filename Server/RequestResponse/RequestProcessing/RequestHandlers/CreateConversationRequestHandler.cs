using AutoMapper;
using Common.Network;
using Server.EFCore.DatabaseServices;
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
        public CreateConversationRequestHandler(IMapper mapper, IConnectionController connectionController) : base(mapper, connectionController)
        {
        }

        protected override void OnError(NetworkMessage networkMessage, ServerNetworkProvider networkProvider)
        {
            CreateConversationResponse errorResponse = new CreateConversationResponse(NetworkResponseStatus.FatalError);
        }

        protected override byte[] OnProcess(DbService dbService, NetworkMessage networkMessage, IServerNetworkProvider networkProvider)
        {
            throw new NotImplementedException();
        }


    }
}
