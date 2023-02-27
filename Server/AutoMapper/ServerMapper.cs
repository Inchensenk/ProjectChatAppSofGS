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

        /// <summary>
        /// Поле хранит конфигурацию для маппинга диалога
        /// </summary>
        private Profile _conversationProfile;

        /// <summary>
        /// Поле хранит конфигурацию для маппинга сообщения
        /// </summary>
        private Profile _messageProfile;

        /// <summary>
        /// Поле хранит конфигурацию для маппинга пользователя
        /// </summary>
        private Profile _userProfile;

        /// <summary>
        /// Хранит конфигурацию для маппинга авторизации
        /// </summary>
        private Profile _signInProfile;

        /// <summary>
        /// Поле хранит конфигурацию для маппинга регистрации
        /// </summary>
        private Profile _signUpProfile;


        private ServerMapper()
        {
            _conversationProfile = new ConversationMapperConfiguration();
            _messageProfile = new MessageMapperConfiguration();
            _userProfile = new UserMapperConfiguration();
            _signInProfile = new SignInMapperConfiguration();
            _signUpProfile = new SignUpMapperConfiguration();
        }

        /// <summary>
        /// Получение единственного экземпляра мапинга
        /// </summary>
        /// <returns>Единственный экземпляр ServerMapper</returns>
        public static ServerMapper GetInstance()
        {
            //Если _instance равен NULL то присваиваем ему единственны экземпляр класса для маппинга
            _instance ??= new ServerMapper();

            return _instance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMapper CreateIMapper() => new MapperConfiguration(cfg => 
        {
            cfg.AddProfile(_userProfile);
            cfg.AddProfile(_conversationProfile);
            cfg.AddProfile(_messageProfile);
            cfg.AddProfile(_signInProfile);
            cfg.AddProfile(_signUpProfile);
        }).CreateMapper();
    }
}
