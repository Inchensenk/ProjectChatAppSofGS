using Client.DbContexts;
using Client.ViewModels;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Windows;
using MVVMEssentials.Stores;
using MVVMEssentials.Services;
using System;
using MVVMEssentials.ViewModels;
using System.Windows.Navigation;

namespace ProjectChatAppSofGS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
            _modalNavigationStore = new ModalNavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService navigationService = CreateAuthorizationNavigationService();
            navigationService.Navigate();


            //Главное окно с контекстом данных
            MainWindow = new MainWindow()
            {
               
                DataContext = new MainViewModel(_navigationStore, _modalNavigationStore)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }

        private INavigationService CreateAuthorizationNavigationService()
        {
            return new NavigationService<AuthorizationUserControlViewModel>(_navigationStore, CreateAuthorizationViewModel);
        }

        private AuthorizationUserControlViewModel CreateAuthorizationViewModel()
        {
            return new AuthorizationUserControlViewModel(CreateChatsNavigationServise());
        }

        private INavigationService CreateChatsNavigationServise()
        {
            return new NavigationService<AuthorizationUserControlViewModel>(_navigationStore, CreateChatsViewModel);
        }

        private AuthorizationUserControlViewModel CreateChatsViewModel()
        {
            return new AuthorizationUserControlViewModel(CreateAuthorizationNavigationService());
        }
    }
}

