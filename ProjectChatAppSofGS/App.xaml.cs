using Client.DbContexts;
using Client.Stores;
using Client.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
        private const string CONNECTION_STRING = "@Data Source=s-dev-01; " +
                                                  "Database=ChatAppSofDB; " +
                                                  "Integrated Security=True;" +
                                                  "Connect Timeout=30; " +
                                                  "Encrypt=False; " +
                                                  "TrustServerCertificate=False; " +
                                                  "ApplicationIntent=ReadWrite; " +
                                                  "MultiSubnetFailover=False";

        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options= new DbContextOptionsBuilder().UseSqlServer(CONNECTION_STRING).Options;

            using (ApplicationDbContext dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.Migrate();
            }

            //////////////////////

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(_navigationStore)
            };

        }
    }
}
