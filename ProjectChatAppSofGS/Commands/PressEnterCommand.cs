using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Commands
{
    
    public class PressEnterCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter, KeyEventArgs e)
        {
            /*Надо сделать*/
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
