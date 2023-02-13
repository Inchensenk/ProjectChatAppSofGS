using Client.Commands;
using Client.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        /// <summary>
        /// Команда закрытия окна по нажатию на кнопку
        /// </summary>
        public ICommand CloseWindowCommand { get; set; }

        /// <summary>
        /// Комманда сворачивания окна
        /// </summary>
        public ICommand MinimizingWindowCommand { get; set; }

        /// <summary>
        /// Комманда разворачивает окно на весь экран
        /// </summary>
        public ICommand MaximizingWindowCommand { get; set; }

        public ICommand DragWindowCommand { get; set; }

        private readonly NavigationStore _navigationStore;

        /// <summary>
        /// Получаем текущую модель представления из хранилища навигации
        /// </summary>
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;/*Текущее свойство вью модел в основной модели просмотра, которое определяет представление для приложения*/

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            CloseWindowCommand = new CloseWindowCommand();
            MinimizingWindowCommand = new MinimizingWindowCommand();
            MaximizingWindowCommand = new MaximizingWindowCommand();
            DragWindowCommand=new BorderMouseDownCommand();
        
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

           
        }


        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
