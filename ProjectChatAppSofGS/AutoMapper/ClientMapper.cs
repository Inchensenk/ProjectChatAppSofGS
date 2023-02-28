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
        /// Поле хранит конфигурацию для маппинга поиска
        /// </summary>
        private Profile _searchProfile;

        /// <summary>
        /// Поле хранит конфигурацию для маппинга авторизации
        /// </summary>
        private Profile _signInProfile;

        /// <summary>
        /// Поле хранит конфигурацию для маппинга выхода из аккаунта
        /// </summary>
        private Profile _signOutProfile;

        /// <summary>
        /// Поле хранит конфигурацию для маппинга регистрации в аккаунте
        /// </summary>
        private Profile _signUpProfile;






        public ClientMapper()
        {
            _signUpProfile = new SignUpMapperConfiguration();
            _signOutProfile = new SignOutMapperConfiguration();
            _signInProfile = new SignInMapperConfiguration();
            _searchProfile = new SearchMapperConfiguration();
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
            cfg.AddProfile(_signUpProfile);
            cfg.AddProfile(_signOutProfile);
            cfg.AddProfile(_signInProfile);
            cfg.AddProfile(_searchProfile);
            cfg.AddProfile(_userProfile);
            cfg.AddProfile(_conversationProfile);
            cfg.AddProfile(_messageProfile);
        }).CreateMapper();
    }
}
