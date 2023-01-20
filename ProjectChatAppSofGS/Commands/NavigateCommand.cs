﻿using Client.Services;
using ProjectChatAppSofGS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using NavigationService = Client.Services.NavigationService;

namespace Client.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}