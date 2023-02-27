using AutoMapper;
using Common.DTO.Responses;
using Common.Network;
using Server.EFCore.DatabaseServices;
using Server.Net.Interfaces;
using Server.RequestResponse.Responses;
using System.Net.Http.Headers;
using System.Text;


namespace Server.RequestResponse.RequestProcessing.RequestHandlers
{
    /// <summary>
    /// Базовый абстрактный класс - бработчик сетевого сообщения
    /// </summary>
    public abstract class RequestHandler
    {
        /// <summary>
        /// Маппер для мапинга DTO
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// Отвечает за соединение по сети с клиентами
        /// </summary>
        protected readonly IConnectionController _conectionController;

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="mapper">Маппер</param>
        /// <param name="connectionController">Отвечает за соединение по сети с клиентами</param>
        public RequestHandler(IMapper mapper, IConnectionController connectionController)
        {
            _mapper = mapper;
            _conectionController = connectionController;
        }

        /// <summary>
        /// Обработать сетевое сообщение
        /// </summary>
        /// <param name="dbService">Сервис для работы с базой данных</param>
        /// <param name="networkMessage">Сетевое сообщение</param>
        /// <param name="networkProvider">Сетевой провайдер</param>
        /// <returns>Ответ на сетевое сообщение в виде массива байт</returns>
        public byte[] Process(DbService dbService, NetworkMessage networkMessage, IServerNetworkProvider networkProvider)
        {
            try
            {
                return OnProcess(dbService, networkMessage, networkProvider);
            }

            catch (IOException)
            {
                throw;
            }

            catch (Exception)
            {
                OnError(networkMessage, networkProvider);
                throw;
            }
        }

        /// <summary>
        /// Обрабатывает ошибку возникшую при обработке сетевого сообщения
        /// Ошибка скорее всего может бть связана с базой данных
        /// </summary>
        /// <param name="networkMessage">Сетевое сообщение</param>
        /// <param name="networkProvider">Сетевой провайдер</param>
        protected virtual void OnError(NetworkMessage networkMessage, IServerNetworkProvider networkProvider)
        {
            Response response = new(NetworkResponseStatus.FatalError);
            SendErrorResponse<Response, ResponseDTO>(networkProvider, response, NetworkMessageCode.DeleteMessageResponseCode);

        }

        private void SendErrorResponse<TResponse, TResponseDTO>(IServerNetworkProvider networkProvider, TResponse response, NetworkMessageCode deleteMessageResponseCode)
            where TResponseDTO : class
        {
            byte[] responseBytes = NetworkMessageConverter<TResponse, TResponseDTO>.Convert(response, code);

            //_conectionController.BroadcastError(responseBytes, networkProvider);
        }




        /// <summary>
        /// Обрабатывает сетевое сообщение
        /// </summary>
        /// <param name="dbService">Сервис для работы с базой данных</param>
        /// <param name="networkMessage">Сетевое сообщение</param>
        /// <param name="networkProvider">Сетевой провайдер</param>
        /// <returns>Ответ на сетевое сообщение в виде массива байт</returns>
        protected abstract byte[] OnProcess(DbService dbService, NetworkMessage networkMessage, IServerNetworkProvider networkProvider);
    }
}
