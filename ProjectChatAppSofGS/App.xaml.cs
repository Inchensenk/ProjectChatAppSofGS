using Client.DbContexts;
using Client.Stores;
using Client.ViewModels;
using FluentAssertions.Common;
using Microsoft.AspNet.SignalR.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace ProjectChatAppSofGS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Строка подключения
        /// </summary>
        private const string CONNECTION_STRING = @"Server=s-dev-01;Database=ChatAppSofDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite; MultiSubnetFailover=False";

        private readonly IHost _host;

        private readonly NavigationStore _navigationStore;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddViewModels()
                .ConfigureServices((HostContext, Services)

            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options= new DbContextOptionsBuilder().UseSqlServer(CONNECTION_STRING).Options;

            using (ApplicationDbContext dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureCreated();
                var canConnect = dbContext.Database.CanConnect();
                dbContext.Database.Migrate();
            }

            _navigationStore.CurrentViewModel = CreateRegistrationUserControlViewModel();

            //Главное окно с контекстом данных
            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(_navigationStore)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }

        private RegistrationUserControlViewModel CreateRegistrationUserControlViewModel()=> new RegistrationUserControlViewModel();
       
    }
}
