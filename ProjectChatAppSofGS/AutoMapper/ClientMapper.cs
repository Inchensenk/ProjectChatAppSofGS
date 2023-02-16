using AutoMapper;
using Client.AutoMapper.Profiles;
using Server.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.AutoMapper
{
    /// <summary>
    /// Маппер клиента, для маппинга DTO
    /// </summary>
    public sealed class ClientMapper
    {
        /// <summary>
        /// Единственный экземпляр мапера
        /// </summary>
        private static ClientMapper _instance;

        /// <summary>
        /// Поле хранит конфигурацию для маппинга авторизации
        /// </summary>
        private Profile _authorizationProfile;

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


        public ClientMapper()
        {
            _authorizationProfile = new AuthorizationMapperConfiguration();
            _conversationProfile = new ConversationMapperConfiguration();
            _messageProfile = new MessageMapperConfiguration();
            _userProfile = new UserMapperConfiguration();
        }

        /// <summary>
        /// Метод получения единственного экземпляра мапинга
        /// </summary>
        /// <returns>Единственный экземпляр MessengerMapper</returns>
        public static ClientMapper GetInstance()
        {
            //Если _instance равен NULL то присваиваем ему единственны экземпляр класса для маппинга
            _instance ??= new ClientMapper();

            return _instance;
        }

        /// <summary>
        /// Создание маппера
        /// </summary>
        /// <returns>Маппер</returns>
        public IMapper CreateIMapper() => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(_userProfile);
            cfg.AddProfile(_authorizationProfile);
            cfg.AddProfile(_conversationProfile);
            cfg.AddProfile(_messageProfile);
        }).CreateMapper();
    }
}
