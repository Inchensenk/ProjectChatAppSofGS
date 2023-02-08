using Client.Commands;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;
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
  
        ///// <summary>
        ///// Команда закрытия окна по нажатию на кнопку
        ///// </summary>
        //public ICommand CloseWindowCommand { get; set; }

        ///// <summary>
        ///// Комманда сворачивания окна
        ///// </summary>
        //public ICommand MinimizingWindowCommand { get; set; }

        ///// <summary>
        ///// Комманда разворачивает окно на весь экран
        ///// </summary>
        //public ICommand MaximizingWindowCommand { get; set; }

        ////public ICommand DragWindowCommand { get; set; }

        public ICommand ChatsNavigationCommand { get; set; }
        public MainWindowViewModel(INavigationService chatsNavigationService)
        {
            //CloseWindowCommand = new CloseWindowCommand();
            //MinimizingWindowCommand = new MinimizingWindowCommand();
            //MaximizingWindowCommand = new MaximizingWindowCommand();
            ////DragWindowCommand=new BorderMouseDownCommand();

            ChatsNavigationCommand = new NavigateCommand(chatsNavigationService);

        }

        
 

    }
}
