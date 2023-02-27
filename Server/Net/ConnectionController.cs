using Server.Net.Interfaces;
using Server.RequestResponse.RequestProcessing;
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
        /// Обработчик события удаления агрегатором всех подключений одного пользователя
        /// </summary>
        /// <param name="userProxyId">Id агрегатора всех подключений одного пользователя</param>
        private void OnUserProxyLastConnectioRemoved(int userProxyId)
        {
            _userProxyList[userProxyId].LastConnectionRemoved -= OnUserProxyLastConnectioRemoved;
            _userProxyList.Remove(userProxyId);
        }


        /// <summary>
        /// Добавить новую сессию
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="networkProviderId">Id сетевого провайдера через который подключился пользователь</param>
        public void AddNewSession(int userId, int networkProviderId)
        {
             if (_userProxyList.ContainsKey(userId))
            {
                _userProxyList[userId].AddConnection(_networkProvidersBuffer[networkProviderId]);
            }
            else
            {
                UserProxy userProxy = new UserProxy(userId);
                userProxy.LastConnectionRemoved += OnUserProxyLastConnectioRemoved;
                userProxy.AddConnection(_networkProvidersBuffer[networkProviderId]);

                _userProxyList.Add(userId, userProxy);
            }

            _networkProvidersBuffer.Remove(networkProviderId);
        }


        /// <summary>
        /// Транслировать ошибку клиенту, который отправил запрос
        /// </summary>
        /// <param name="messageBytes">Сетевое сообщение представленное массивом байт</param>
        /// <param name="networkProvider">Сетевой провайдер</param>
        public async Task BroadcastError(byte[] messageBytes, IServerNetworkProvider networkProvider)
        {
            await networkProvider.SendBytesAsync(messageBytes);
        }


        /// <summary>
        /// Транслировать сообщения всем клиентам, на которых авторизован пользователь-собеседник
        /// </summary>
        /// <param name="messageBytes">Сетевое сообщение представленное массивом байт</param>
        /// <param name="interlocutorId">Id пользователя - собеседника, пользователя который отправил запрос</param>
        public async Task BroadcastToInterlocutorAsync(byte[] messageBytes, int interlocutorId)
        {
            if (_userProxyList.ContainsKey(interlocutorId))
                await _userProxyList[interlocutorId].BroadcastNetworkMessageAsync(messageBytes);
        }

        /// <summary>
        /// Транслировать сообщения всем клиентам, на которых авторизован пользователь кроме указанного
        /// </summary>
        /// <param name="messageBytes">Сетевое сообщение представленное массивом байт</param>
        /// <param name="userId">Id пользователя</param>
        /// <param name="networkProviderId">Id сетевого провайдера, которому не нужно отправлять сообщение</param>
        public async Task BroadcastToSenderAsync(byte[] messageBytes, int userId, int networkProviderId)
        {
            await _userProxyList[userId].BroadcastNetworkMessageAsync(messageBytes, networkProviderId);
        }

        /// <summary>
        /// Удалить сессию конкретного пользователя связанную с конкретным сетевым провайдером
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="networkProviderId">Id сетвого провайдера</param>
        public void DisconnectUser(int userId, int networkProviderId)
        {
            _userProxyList[userId].RemoveConnection(networkProviderId);
        }


        /// <summary>
        /// Обработать запрос в виде массива байт
        /// </summary>
        /// <param name="request">Запрос от клиента</param>
        /// <param name="networkProvider">Сетевой провайдер</param>
        private void ProcessRequest(byte[] request, IServerNetworkProvider networkProvider)
        {
            byte[] response = _requestController.ProcessRequest(request, networkProvider);

            networkProvider.SendBytesAsync(response);
        }


        /// <summary>
        /// Инициализировать новое подключение
        /// </summary>
        /// <param name="tcpClient">TCP клиент</param>
        public void InitializeNewConnection(TcpClient tcpClient)
        {
            ServerNetworkProvider networkProvider = new ServerNetworkProvider(tcpClient);
            networkProvider.BytesReceived += ProcessRequest;

            _networkProvidersBuffer.Add(networkProvider.Id, networkProvider);

            Console.WriteLine($"Клиент {networkProvider.Id} подключился ");

            Task.Run(() => networkProvider.ProcessNetworkMessagesAsync());
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
