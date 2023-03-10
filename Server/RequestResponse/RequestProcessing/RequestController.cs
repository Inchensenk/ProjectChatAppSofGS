using AutoMapper;
using Common.Network;
using Common.Serialization;
using Server.AutoMapper;
using Server.EFCore.DatabaseServices;
using Server.Net;
using Server.Net.Interfaces;
using Server.RequestResponse.RequestProcessing.RequestHandlers;


namespace Server.RequestResponse.RequestProcessing
{
    /// <summary>
    /// Управление обработкой запросов отправленных клиентами
    /// </summary>
    public class RequestController : IRequestController
    {
        /// <summary>
        /// Отвечает за соединение по сети с клиентами
        /// </summary>
        private IConnectionController _conectionController;

        /// <summary>
        /// Маппер для мапинга DTO
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Сервис для работы с базами данных
        /// </summary>
        private readonly DbService _dbService;

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="connectionController">Отвечает за соединение по сети с клиентами</param>
        public RequestController(IConnectionController connectionController)
        {
            ServerMapper mapper = ServerMapper.GetInstance();
            _mapper = mapper.CreateIMapper();

            _dbService = new DbService(_mapper);
            _conectionController = connectionController;
        }

        /// <summary>
        /// Обработать запрос от клиента в виде массива байт
        /// </summary>
        /// <param name="request">Pапрос от клиента</param>
        /// <param name="networkProvider">Сетевой провайдер</param>
        /// <returns>Ответ на запрос клиента в виде массива байт</returns>
        public byte[] ProcessRequest(byte[] request, IServerNetworkProvider networkProvider)
        {
            NetworkMessage requestMessage = SerializationHelper.Deserialize<NetworkMessage>(request);

            byte[] response = ProcessRequestMessage(requestMessage, networkProvider);

            return response;
        }

        /// <summary>
        /// Обработка сетевого сообщения
        /// </summary>
        /// <param name="networkMessage">Сетевое сообщение</param>
        /// <param name="networkProvider">Сетевой провайдер отправивший запрос</param>
        /// <returns>Ответ на запрос клиента в виде массива байт</returns>
        private byte[] ProcessRequestMessage(NetworkMessage networkMessage, IServerNetworkProvider networkProvider)
        {
            RequestHandler handler = RequestHandlerCreator.FactoryMethod(_mapper, _conectionController, networkMessage.Code);

            return handler.Process(_dbService, networkMessage, networkProvider);
        }

    }
}
