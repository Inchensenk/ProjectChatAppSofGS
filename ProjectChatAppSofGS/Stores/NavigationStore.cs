using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Stores
{
    /// <summary>
    /// Хранит состояние навигации, 
    /// то есть какя модель представления должна отоброжаться в главном окне приложения
    /// </summary>
    public class NavigationStore
    {
        /// <summary>
        /// Событие изменения текущей модели представления
        /// </summary>
        public event Action CurrentViewModelChanged;/*Всякий раз когда мы устанавливаем нове значение для текущей модели представления, мы должны будем вызвать это событие */

        /*
        /// <summary>
        /// Модель домашнего просмотра
        /// Текущая модель представления, Определяет на каком виде мы сейчас находимся
        /// set; - для того чтобы мы могли изменять состояние навигации для приложения и фактически переключать представдение
        /// </summary>
        public ViewModelBase CurrentViewModel { get; set; }*/

        /// <summary>
        /// Текущее поле модели представления
        /// </summary>
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;/*устанавливаем для текущего поля модели представления заданное значение*/
                OnCurrentViewModelChanged();/*вызываем событие изменения текущей модели представления*/
            }

        }

        /// <summary>
        /// вызываем событие изменения текущей модели представления
        /// </summary>
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();/*если на событие кто-то подписан, то вызываем это событие*/
        }
    }
}
