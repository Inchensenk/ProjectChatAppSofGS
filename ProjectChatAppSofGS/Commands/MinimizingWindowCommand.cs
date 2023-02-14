using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client.Commands
{
    /// <summary>
    /// Команда сворачиваниня окна приложения
    /// </summary>
    public class MinimizingWindowCommand : BaseCommand
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
