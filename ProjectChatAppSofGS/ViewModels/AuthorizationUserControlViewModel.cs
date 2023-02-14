using Client.Commands;
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
        /// <summary>
        /// Команда для отоброжения в главной модели представления модели представления чатов
        /// </summary>
        public ICommand NavigateChatsCommand { get; }

        /// <summary>
        /// Команда для отоброжения в главной модели представления модели представления регистрации
        /// </summary>
        public ICommand NavigateRegistrationCommand { get; }

        public AuthorizationUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateChatsCommand = new NavigateCommand<ChatsUserControlViewModel>(navigationStore, () => new ChatsUserControlViewModel(navigationStore));

            NavigateRegistrationCommand = new NavigateCommand<RegistrationUserControlViewModel>(navigationStore, () => new RegistrationUserControlViewModel(navigationStore));
        }
    }
}
