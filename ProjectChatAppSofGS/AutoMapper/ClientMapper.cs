using AutoMapper;
using Server.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.AutoMapper
{
    public sealed class ServerMapper
    {
        private static ServerMapper _instance;

        private Profile _authorizationProfile;
        private Profile _conversationProfile;
        private Profile _messageProfile;
        private Profile _userProfile;
            


        public ServerMapper()
        {
            _instance = null!;

            _authorizationProfile = new AuthorizationMapperConfiguration();
            _conversationProfile = new ConversationMapperConfiguration();
            _messageProfile = new MessageMapperConfiguration();
            _userProfile = new UserMapperConfiguration();
        }

    }
}
