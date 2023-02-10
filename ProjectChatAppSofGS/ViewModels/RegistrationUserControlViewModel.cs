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
    class RegistrationUserControlViewModel : ViewModelBase
    {
        /// <summary>
        /// Команда для перехода в окно авторизации
        /// </summary>
        public ICommand NavigateAuthorizationCommand { get; }

        public RegistrationUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateAuthorizationCommand = new NavigateCommand<AuthorizationUserControlViewModel>(navigationStore, () => new AuthorizationUserControlViewModel(navigationStore));
        }
    }
}
