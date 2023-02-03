using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Stores
{
    /// <summary>
    /// Класс навигации, хранит текущую VM для приложения
    /// </summary>
    public class NavigationStore
    {
        /// <summary>
        /// Текущая Вью модель для приложения
        /// </summary>
        private ViewModelBase _currentViewModel = null!;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        /// <summary>
        /// Событие изменения главного окна
        /// </summary>
        public event Action CurrentViewModelChanged = null!;

        /// <summary>
        /// Метод вызывающий текущую VM
        /// </summary>
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
