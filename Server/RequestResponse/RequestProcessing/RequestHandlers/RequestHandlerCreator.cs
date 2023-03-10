using AutoMapper;
using Common.Network;
using Server.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestResponse.RequestProcessing.RequestHandlers
{
    /// <summary>
    /// Создает с помощью фабричного метода экземпляр конкретного обработчика запроса от клиента
    /// </summary>
    public class RequestHandlerCreator
    {
        /// <summary>
        /// Фабричный метод создания обработчика запроса от клиента
        /// </summary>
        /// <param name="mapper">Маппер для мапинга DTO</param>
        /// <param name="connectionController">Jтвечает за соединение по сети с клиентами</param>
        /// <param name="code">Код сетевого сообщения</param>
        /// <returns>Обработчик сетевого сообщения</returns>
        public static RequestHandler FactoryMethod(IMapper mapper, IConnectionController connectionController, NetworkMessageCode code)
        {
            switch (code)
            {
                case NetworkMessageCode.SignUpRequestCode:
                    return new SignUpRequestHandler(mapper, connectionController);

                case NetworkMessageCode.SignInRequestCode:
                    return new SignInRequestHandler(mapper, connectionController);

                case NetworkMessageCode.SearcRequestCode:
                    return new SearchUserRequestHandler(mapper, connectionController);

                case NetworkMessageCode.CreateConversationRequestCode:
                    return new CreateConversationRequestHandler(mapper, connectionController);

                case NetworkMessageCode.SendMessageRequestCode:
                    return new SendMessageRequestHandler(mapper, connectionController);

                case NetworkMessageCode.DeleteMessageRequestCode:
                    return new DeleteMessageRequestHandler(mapper, connectionController);

                case NetworkMessageCode.DeleteConversationRequestCode:
                    return new DeleteConversationRequestHandler(mapper, connectionController);

                case NetworkMessageCode.SignOutRequestCode:
                    return new SignOutRequestHandler(mapper, connectionController);

                case NetworkMessageCode.ReadMessagesRequestCode:
                    return new ReadMessagesRequestHandler(mapper, connectionController);

                default:
                    return null;
            }
        }
    }
}
