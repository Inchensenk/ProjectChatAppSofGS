using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Net.Interfaces
{
    /// <summary>
    /// Интерфейс для соединения с клиентами
    /// </summary>
    public interface IConnectionController
    {
        /// <summary>
        /// Инициализация нового подключения
        /// </summary>
        /// <param name="tcpClient">TCP клиент</param>
        public void InitializeNewConnection(TcpClient tcpClient);

        /// <summary>
        /// Добавление новой сессии
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="networkProviderId">Идентификатор сетевого провайдера через который подключился пользователь</param>
        public void AddNewSession(int userId, int networkProviderId);

        /// <summary>
        /// Трансляция сообщения всем клиентам, на которых авторизован пользователь кроме указанного
        /// </summary>
        /// <param name="messageBytes">Сетевое сообщение в виде массива байт</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="networkProviderId">Идентификатор сетевого провайдера, которому не нужно отправлять сообщение</param>
        /// <returns></returns>
        public Task BroadcastToSenderAsync(byte[] messageBytes, int userId, int networkProviderId);

        /// <summary>
        /// Транслировать сообщения всем клиентам, на которых авторизован пользователь-собеседник
        /// </summary>
        /// <param name="messageBytes">Сетевое сообщение представленное массивом байт</param>
        /// <param name="userId">Идентификатор пользователя</param>
        public Task BroadcastToInterlocutorAsync(byte[] messageBytes, int userId);

        /// <summary>
        /// Транслировать ошибку клиенту, который отправил запрос
        /// </summary>
        /// <param name="messageBytes">Сетевое сообщение представленное массивом байт</param>
        /// <param name="networkProvider">Сетевой провайдер</param>
        public Task BroadcastError(byte[] messageBytes, IServerNetworkProvider networkProvider);

        /// <summary>
        /// Отключить пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="networkPrividerId">Идентификатор сетевого провайдера</param>
        public void DisconnectUser(int userId, int networkPrividerId);
    }
}
