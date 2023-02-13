using Client.ViewModels;

using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Windows;

using System;

using System.Windows.Navigation;
using Client.Stores;

namespace ProjectChatAppSofGS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();/*создаем экземпляр класса хранящии текущую модель представления*/
            navigationStore.CurrentViewModel = new AuthorizationUserControlViewModel(navigationStore);/*устанавливаем текущую модель просмотра в начале приложения на модель авторизации*/

            MainWindow = new MainWindow()
            {
                //Контекст данных для главного окна, основная модель просмотра
                DataContext = new MainWindowViewModel(navigationStore)
            };

            //Показываем главное окно
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}

