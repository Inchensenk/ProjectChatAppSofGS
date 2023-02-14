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
        /// Команда для отоброжения в главной модели представления модели представления авторизации
        /// </summary>
        public ICommand NavigateAuthorizationCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="navigationStore"></param>
        public RegistrationUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateAuthorizationCommand = new NavigateCommand<AuthorizationUserControlViewModel>(navigationStore, () => new AuthorizationUserControlViewModel(navigationStore));
        }
    }
}
