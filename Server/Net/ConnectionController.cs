using Server.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Net
{
    public class ConnectionController : IConnectionController
    {
        /// <summary>
        /// Словарь, который содержит пары: Key - id агрегатора соединений пользователя 
        /// Value - самого агрегатора соединений пользователя 
        /// </summary>
        private Dictionary<int, UserProxy> _userProxyList;

        /// <summary>
        /// Словарь, который  хранит временно подключенных сетевых провайдеров, к которым пока не привязаны пользователи.
        /// Key - Id сетевого провайдера.
        /// Value - объект сетевого провайдера
        /// </summary>
        private Dictionary<int, IServerNetworkProvider> _networkProvidersBuffer;

        /// <summary>
        /// Управляет обработкой запросов отправленных клиентами
        /// </summary>
        private IRequestController _requestController;

        /// <summary>
        /// Сервер, который прослушивает входящие подключения
        /// </summary>
        private Server _server;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ConnectionController()
        {
            _server = new Server(this);
            _requestController = new RequestController(this);
            _userProxyList = new Dictionary<int, UserProxy>();
            _networkProvidersBuffer = new Dictionary<int, IServerNetworkProvider>();
        }

        /// <summary>
        /// Асинхронный метод - начать работу контроллера
        /// </summary>
        public async Task RunAsync()
        {
            try
            {
                await _server.ListenIncomingConnectionsAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _server.Stop();
            }
        }
    }
}
