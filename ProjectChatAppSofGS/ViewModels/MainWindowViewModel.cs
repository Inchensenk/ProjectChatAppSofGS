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
        /// хранилище навигации
        /// </summary>
        private readonly NavigationStore _navigationStore;

        /// <summary>
        /// Текущая вьюмодель для приложения
        /// </summary>
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

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
        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            CloseWindowCommand = new CloseWindowCommand();
            MinimizingWindowCommand = new MinimizingWindowCommand();
            MaximizingWindowCommand = new MaximizingWindowCommand();
            DragWindowCommand=new BorderMouseDownCommand();
        }

       
       

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void CloseWindow()
        {
            Application.Current.Shutdown();
        }
    }
}
