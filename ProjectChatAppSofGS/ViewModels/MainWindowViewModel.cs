using Client.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
