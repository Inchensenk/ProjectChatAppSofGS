using Client.ViewModels;
using System;
using System.Collections.Generic;
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

        private User _currentUser;

        private bool _areThereAnyHaveUnreadMessages;

        /// <summary>
        /// Свойство: Идентификатор
        /// </summary>
        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Свойство: Текущий пользователь
        /// </summary>
        public User CurrentUser
        {
            get => _currentUser;
            set { _currentUser = value; OnPropertyChanged();}
        }

        //public string Title => User;
    }
}
