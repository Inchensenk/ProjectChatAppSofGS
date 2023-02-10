﻿using Client.Commands;
using Client.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.ViewModels
{
    public class AuthorizationUserControlViewModel : ViewModelBase
    {
        /*
        /// <summary>
        /// Команда для перемещения в окно навигации
        /// </summary>
        public ICommand NavigateChatsCommand { get;}

        public AuthorizationUserControlViewModel(INavigationService chatsNavigationService)
        {
            NavigateChatsCommand = new NavigateCommand(chatsNavigationService);
        }

        //public ICommand NavigateRegistrationCommand { get;}
        //public AuthorizationUserControlViewModel(INavigationService registrationNavigationService)
        //{
        //    NavigateRegistrationCommand = new
        //}
        */

        public ICommand NavigateChatsCommand { get; }

        public ICommand NavigateRegistrationCommand { get; }

        public AuthorizationUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateChatsCommand = new NavigateCommand<ChatsUserControlViewModel>(navigationStore, () => new ChatsUserControlViewModel(navigationStore));

            NavigateRegistrationCommand = new NavigateCommand<RegistrationUserControlViewModel>(navigationStore, () => new RegistrationUserControlViewModel(navigationStore));
        }
    }
}
