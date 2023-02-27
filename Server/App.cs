using Server.Net;
using Server.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// Приложение - серверная часть мессенжера
    /// </summary>
    public class App
    {
        /// <summary>
        /// Отвечает за соединение по сети с клиентами
        /// </summary>
        private ConnectionController _connectionController;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public App()
        {
            _connectionController = new ConnectionController();
        }

        /// <summary>
        /// Запустить приложение асинхронно
        /// </summary>
        public async Task LaunchAsync()
        {
            await _connectionController.RunAsync();
        }
    
    }
}
