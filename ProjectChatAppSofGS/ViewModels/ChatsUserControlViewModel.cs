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
    /// <summary>
    /// Модель представления чатов
    /// </summary>
    class ChatsUserControlViewModel : ViewModelBase
    {

        /// <summary>
        /// Команда для отоброжения в главной модели представления модели представления авторизации
        /// </summary>
        public ICommand NavigateAuthorizationCommand {get;}

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="navigationStore">Класс NavigationStore хранит текущую модель представления</param>
        public ChatsUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateAuthorizationCommand = new NavigateCommand<AuthorizationUserControlViewModel>(navigationStore, ()=> new AuthorizationUserControlViewModel(navigationStore));
        }

    }
}
