using Client.Commands;
using Client.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.ViewModels
{
    class ChatsUserControlViewModel : ViewModelBase
    {
        /*
        public ICommand NavigateAuthorizationCommand { get; }

        public ChatsUserControlViewModel(INavigationService authorizationNavigationService)
        {
            NavigateAuthorizationCommand = new NavigateCommand(authorizationNavigationService);
        }
        */

        public ICommand NavigateAuthorizationCommand {get;}

        public ChatsUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateAuthorizationCommand = new NavigateCommand<AuthorizationUserControlViewModel>(navigationStore, ()=> new AuthorizationUserControlViewModel(navigationStore));
        }

    }
}
