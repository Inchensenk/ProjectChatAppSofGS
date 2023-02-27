using AutoMapper;
using Common.DTO.Requests;
using Microsoft.EntityFrameworkCore;
using Server.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.EFCore.DatabaseServices
{
    /// <summary>
    /// Сервис для работы с БД
    /// </summary>
    public class DbService
    {
        /// <summary>
        /// Маппер для DTO
        /// </summary>
        private readonly IMapper _mapper;

        public DbService(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Добавление нового пользователя в БД
        /// </summary>
        /// <param name="signUpRequestDTO">DTO с данными о регистрации</param>
        /// <returns>При успешном добавлении в БД возвращается пользователь, в противном случае возвращается null</returns>
        public User? AddNewUser(SignUpRequestDTO signUpRequestDTO)
        {
            using (var dbContext = new ChatDbContext())
            {
                User? user = FindUserByPhoneNumber(signUpRequestDTO.PhoneNumber, dbContext);

                if (user == null)
                {
                    user = _mapper.Map<User>(signUpRequestDTO);
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                    return user;
                }                
                return null;
            }
        }

        /// <summary>
        /// При прочтении сообщения статус IsRead у Message меняется на true
        /// </summary>
        /// <param name="readMessagesRequest">Запрос на прочтение сообщений</param>
        public void ReadMessages(ExtendedReadMessagesRequestDTO readMessagesRequest)
        {
            using (var dbContext = new ChatDbContext())
            {
                var messagesAreReadId = readMessagesRequest.MessagesId;

                List<Message> messagesList = dbContext.Conversations
                                                      .Include(conversation => conversation.MessageListinc)
                                                      .First(conversation => conversation.Id == readMessagesRequest.ConversationId)
                                                      .MessageListinc.ToList();

                foreach (int id in messagesAreReadId)
                {
                    messagesList.First(message => message.Id == id)
                                .IsRead = true;
                }

                dbContext.SaveChanges();
            }
        }


        /// <summary>
        /// Поиск пользователя по номеру телефона
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>Если пользовательнайден, то возвращается найденный пользователь, в противном случае возвращается null</returns>
        public User? FindUserByPhoneNumber(string phoneNumber)
        {
            using (var dbContext = new ChatDbContext())
            {
                return dbContext.Users
                                .FirstOrDefault(user => user.PhoneNumber == phoneNumber);
            }
        }

        /// <summary>
        /// Поиск пользователя по номеру телефона, перегрузка принимающая на входе контекст базы данных и строку с номером телефона
        /// </summary>
        /// <param name="phoneNumber">номер телефона</param>
        /// <param name="dbContext">Контекст базы данных</param>
        /// <returns>Если пользователь найден, то возвращается найденный пользователь, в противном случае возвращается null</returns>
        public static User? FindUserByPhoneNumber(string phoneNumber, ChatDbContext dbContext)
        {
            return dbContext.Users
                            .FirstOrDefault(user => user.PhoneNumber == phoneNumber);
        }

        /// <summary>
        /// Поиск пользователя в базе данных с использованием информации о запросе на вход в мессенджер
        /// </summary>
        /// <param name="signInRequestDTO">DTO запрос входа в аккаунт</param>
        /// <returns>Если пользователь найден, то возвращается найденный пользователь, в противном случае возвращается null</returns>
        public static User? FindUser(SignInRequestDTO signInRequestDTO)
        {
            using (var dbContext = new ChatDbContext())
            {
                return dbContext.Users
                                .Include(user => user.ConversationListinc)
                                .FirstOrDefault(user => user.PhoneNumber == signInRequestDTO.PhoneNumber && user.Password == signInRequestDTO.Password);
            }
        }

        /// <summary>
        /// Поиск всех бесед пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Список бесед</returns>
        public List<Conversation> FindConversationsByUser(User user)
        {
            using (var dbContext = new ChatDbContext())
            {
                return dbContext.Conversations
                                .Include(conversation => conversation.UserListinc)
                                .Include(conversation => conversation.MessageListinc)
                                .ThenInclude(message => message.FromUser)
                                .Where(conversation => conversation.UserListinc.Contains(user)).ToList();
            }
        }

        /// <summary>
        /// Найти пользователей удовлетворяющих поиску, при неудаче возвращает пустой список
        /// </summary>
        /// <param name="searchRequestDto">DTO поискового запроса</param>
        /// <returns>Список пользователей удовлетворяюзщих поисковому запросу</returns>
        public List<User> FindListOfUsers(SearchRequestDTO searchRequestDTO)
        {
            using (var dbContext = new ChatDbContext())
            {
                return dbContext.Users
                                .Where(user => user.PhoneNumber == searchRequestDTO.PhoneNumber || (searchRequestDTO.FirstName != "" && user.FirstName.ToLower().Contains(searchRequestDTO.FirstName.ToLower()))).ToList();
            }
        }




        //--//--//--//
        /// <summary>
        /// Создает беседу в базе данных
        /// </summary>
        /// <param name="dto">DTO - запрос на создание беседы</param>
        /// <returns>Созданная в базе данных беседа</returns>
        public Conversation CreateConversation(CreateConversationRequestDTO dto)
        {
            using (var dbContext = new ChatDbContext())
            {
                Conversation conversation = _mapper.Map<Conversation>(dto);
                int fromUserId = conversation.MessageListinc.First().FromUserId;

                foreach (var userId in dto.UsersId)
                {
                    User user = dbContext.Users.First(user => user.Id == userId);
                    conversation.UserListinc.Add(user);
                }

                conversation.MessageListinc.First().FromUser = conversation.UserListinc.First(user => user.Id == fromUserId);

                dbContext.Add(conversation);
                dbContext.SaveChanges();

                return conversation;
            }
        }
        //--//--//--//

        /// <summary>
        /// Поиск беседы в базе данных
        /// </summary>
        /// <param name="deleteConversationRequestDTO">DTO - запрос на удаление беседы</param>
        /// <returns>Найденная беседа, если она существует в базе данных, иначе null</returns>
        public Conversation? FindConversation(ExtendedDeleteConversationRequestDTO deleteConversationRequestDTO)
        {
            using (var dbContext = new ChatDbContext())
            {
                return dbContext.Conversations
                                .Include(conversastion => conversastion.UserListinc)
                                .FirstOrDefault(conversastion => conversastion.Id== deleteConversationRequestDTO.ConversationId);
            }
        }

        /// <summary>
        /// Создает сообщение и записывает его в БД
        /// </summary>
        /// <param name="sendMessageRequestDTO">Dto - запрос на отправку сообщения</param>
        /// <returns>Созданное сообщение</returns>
        public Message AddMessage(SendMessageRequestDTO sendMessageRequestDTO)
        {
            using (var dbContext = new ChatDbContext())
            {
                Message message = _mapper.Map<Message>(sendMessageRequestDTO.Message);

                var user = dbContext.Users
                                    .Include(user => user.ConversationListinc)
                                    .First(user => user.Id == message.FromUser.Id);

                var conversation = dbContext.Conversations
                                            .Include(conversation => conversation.UserListinc)
                                            .First(conversation => conversation.Id == sendMessageRequestDTO.ConversationId);

                message.FromUser = user;
                message.Conversation = conversation;

                dbContext.Messages.Add(message);
                dbContext.SaveChanges();

                return message;
            }
        }

        /// <summary>
        /// Возвращает идентификатор пользователя, которому отправлено сообщение
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <returns>Идентификатор пользователя</returns>
        public int GetRecipientUserId(Message message)
        {
            using (var dbContext = new ChatDbContext())
            {
                return dbContext.Messages
                                .Include(message => message.Conversation)
                                .ThenInclude(Conversation => Conversation.UserListinc)
                                .First(message => message.Id == message.Id).Conversation.UserListinc
                                .First(user => user.Id != message.FromUserId).Id;
            }
        }

        /// <summary>
        /// Поиск сообщения по идентификатору
        /// </summary>
        /// <param name="deleteMessageRequestDTO">Dto запрос на удаление сообщения</param>
        /// <returns>В случае удачного поиска возвращает сообщение, иначе - null</returns>
        public Message? FindMessage(ExtendedDeleteMessageRequestDTO deleteMessageRequestDTO)
        {
            using (var dbContext = new ChatDbContext())
            {
                return dbContext.Messages
                                .Include(mes => mes.Conversation)
                                .Include(mes => mes.FromUser)
                                .FirstOrDefault(mes => mes.Id == deleteMessageRequestDTO.MessageId);
            }
        }

        /// <summary>
        /// Удаление сообщения из БД
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void DeleteMessage(Message message)
        {
            using (var dbContext = new ChatDbContext())
            {
                var mes = dbContext.Messages.Remove(message);

                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Удаляет беседу из базы данных
        /// </summary>
        /// <param name="conversation">Беседа</param>
        public void DeleteConversation(Conversation conversation)
        {
            using (var dbContext = new ChatDbContext())
            {
                var convers = dbContext.Conversations.Remove(conversation);

                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Возвращает идентификатор пользователя, который является собеседником определенного пользователя в определенной беседе
        /// </summary>
        /// <param name="conversationId">Идентификатор беседы</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Идентификатор собеседника</returns>
        public int GetInterlocutorId(int conversationId, int userId)
        {
            using (var dbContext = new ChatDbContext())
            {
                return dbContext.Conversations
                                .Include(conversation => conversation.UserListinc)
                                .First(conversation => conversation.Id == conversationId)
                                .UserListinc
                                .First(user => user.Id != userId).Id;
            }
        }
    }
}
