using Client.Stores;
using Client.ViewModels;
using ProjectChatAppSofGS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Commands
{
    /// <summary>
    /// Универсальная команда для навигации
    /// </summary>
    /// <typeparam name="TViewModel">Обобщенный тип для модели представления на которую нужно будет перейти</typeparam>
    class NavigateCommand<TViewModel> : CommandBase
        where TViewModel : ViewModelBase/*Ограничение для обобщенного типа, принимаемое значение должно быть классом наследуемым от Базовой модели представления*/
    {
        private readonly NavigationStore _navigationStore;
        /// <summary>
        /// Метод обратного вызова, возвращает текущую модель представления
        /// </summary>
        private readonly Func<TViewModel> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        /// <summary>
        /// Устанавливаем текущую модель просмотра хранилища навигации в модель домашнего просмотра AccountViewModel
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
