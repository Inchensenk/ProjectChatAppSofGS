using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Stores
{
    /// <summary>
    /// Класс навигации хранит текущую VM для приложения
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

        public event Action CurrentViewModelChanged = null!;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
