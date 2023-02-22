﻿using Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestResponse.Responses
{
    /// <summary>
    /// Ответ на запрос создания новой беседы
    /// </summary>
    public class CreateConversationResponse : Response
    {
        public int ConversationId { get; init; }

        public int MessageId { get; init; }

        public CreateConversationResponse() : base() { }

        public CreateConversationResponse(NetworkResponseStatus status) : base(status) { }

        public CreateConversationResponse(int conversationId, int messageId, NetworkResponseStatus status) : base(status)
        {
            ConversationId = conversationId;
            MessageId = messageId;
        }
    }
}
