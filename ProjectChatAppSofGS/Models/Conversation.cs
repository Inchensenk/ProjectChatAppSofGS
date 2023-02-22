using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    /// <summary>
    /// Модель беседы
    /// </summary>
    public class Conversation : ViewModelBase
    {
        /*
        #region Class fields

        /// <inheritdoc cref="Id"/>
        private int _id;

        /// <inheritdoc cref="ConversationName"/>
        private string _conversationName;

        #endregion Class fields

        #region Class properties

        /// <summary>
        /// Свойство: Идентификатор
        /// </summary>
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Свойство: Название диалога
        /// </summary>
        public string ConversationName
        {
            get => _conversationName;
            set
            {
                _conversationName = value;
                OnPropertyChanged();
            }
        }

        #endregion Class properties

        #region Class constructors

        public Conversation()
        {
            Id = 0;
            ConversationName = null!;
        }

        #endregion Class constructors
        */

        /// <inheritdoc cref="Id"/>
        private int _id;

        /// <inheritdoc cref="CurrentUser"/>
        private User _currentUser;

        /// <inheritdoc cref="AreThereAnyHaveUnreadMessages"/>
        private bool _areThereAnyHaveUnreadMessages;

        /// <summary>
        /// Свойство: Идентификатор
        /// </summary>
        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }

        /// <summary>
        /// Свойство: Текущий пользователь
        /// </summary>
        public User CurrentUser { get => _currentUser; set { _currentUser = value; OnPropertyChanged();} }

        /// <summary>
        /// Свойство: Флаг, который хранит информацию прочитано сообщение или нет
        /// </summary>
        public bool AreThereAnyHaveUnreadMessages { get=> _areThereAnyHaveUnreadMessages; set { _areThereAnyHaveUnreadMessages = value; OnPropertyChanged(); } }

        /// <summary>
        /// Список пользователей учавствующих в беседе
        /// </summary>
        public List<User> UserListingСonversationalist { get; set; }

        /// <summary>
        /// Имя беседы будет таким же как и имя собеседника
        /// </summary>
        public string Title => UserListingСonversationalist.First(n => n.Id != _currentUser.Id).FirstName;

        /// <summary>
        /// Обозреваемый список сообщений в беседе
        /// </summary>
        public ObservableCollection<Message> MessageListing { get; init; }



        public Conversation()
        {
            Id= 0;
            UserListingСonversationalist = new List<User>();
            MessageListing = new ObservableCollection<Message>();
        }

        public Conversation(User user1, User user2) : this()
        {
            UserListingСonversationalist.Add(user1);
            UserListingСonversationalist.Add(user2);
        }

        /// <summary>
        /// Проверка: прочитаны последние сообщения или нет
        /// </summary>
        public void CheckLastMessagesRead()
        {
            AreThereAnyHaveUnreadMessages = MessageListing.Count > 0
            && MessageListing.Last().IsCurrentUserMessage == false
            && MessageListing.Last().IsRead == false;
        }
    }
}
