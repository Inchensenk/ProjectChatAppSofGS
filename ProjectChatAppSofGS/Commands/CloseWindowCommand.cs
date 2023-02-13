using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client.Commands
{
    public class CloseWindowCommand : BaseCommand
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }

        public override void Execute(object parameter, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
