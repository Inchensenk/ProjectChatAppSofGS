using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Commands
{
    /// <summary>
    /// реализация от ии
    /// </summary>
    public abstract class BaseCommand : ICommand
    {
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object? parameter);
        public abstract void Execute(object parameter, MouseButtonEventArgs e);


        public event EventHandler? CanExecuteChanged;

        protected void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
