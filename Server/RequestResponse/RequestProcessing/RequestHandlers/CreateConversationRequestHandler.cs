using AutoMapper;
using Common.Network;
using Server.EFCore.DatabaseServices;
using Server.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestResponse.RequestProcessing.RequestHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateConversationRequestHandler : RequestHandler
    {
        public CreateConversationRequestHandler(IMapper mapper, IConnectionController connectionController) : base(mapper, connectionController)
        {
        }

        protected override byte[] OnProcess(DbService dbService, NetworkMessage networkMessage, IServerNetworkProvider networkProvider)
        {
            throw new NotImplementedException();
        }
    }
}
