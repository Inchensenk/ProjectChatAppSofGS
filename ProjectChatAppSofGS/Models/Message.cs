using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Message : ViewModelBase
    {
        #region Class fields
        /*
        /// <inheritdoc cref="Id"/>
        private int _id;

        /// <inheritdoc cref="FromNumber"/>
        private string _fromNumber;

        /// <inheritdoc cref="MessageText"/>
        private string _messageText;

        /// <inheritdoc cref="SendDateTime"/>
        private DateTime _sendDateTime;

        /// <inheritdoc cref="IsCurrentUserMessage"/>
        private bool _isCurrentUserMessage;

        #endregion Class fields

        #region Class properties
        /// <summary>
        /// Свойство: Идентификатор
        /// </summary>
        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }

        /// <summary>
        /// Свойство: Номер отправителя сообщения
        /// </summary>
        public string FromNumber { get => _fromNumber; set { _fromNumber = value; OnPropertyChanged(); } }

        /// <summary>
        /// Свойство: Текст сообщения
        /// </summary>
        public string MessageText { get => _messageText; set { _messageText = value; OnPropertyChanged(); } }

        /// <summary>
        /// Свойство: Время отправки сообщения
        /// </summary>
        public DateTime SendDateTime { get => _sendDateTime; set { _sendDateTime = value; OnPropertyChanged();} }

        public bool IsCurrentUserMessage { get => _isCurrentUserMessage; set { _isCurrentUserMessage = value; OnPropertyChanged(); } }

        #endregion Class properties

        #region Сlass constructors
        public Message()
        {
            Id = 0;
            FromNumber = null!;
            MessageText = null!;
            SendDateTime = DateTime.Now;
            IsCurrentUserMessage = true;
        }
        */
        #endregion Сlass constructors

        /// <inheritdoc cref="Id"/>
        private int _id;

        /// <inheritdoc cref="MessageText"/>
        private string _messageText;

        /// <inheritdoc cref="IsRead"/>
        private bool _isRead;

        private DateTime _sendDateTime;

        /// <inheritdoc cref="FromUser"/>
        private User? _fromUser;

        /// <inheritdoc cref="IsCurrentUserMessage"/>
        private bool _isCurrentUserMessage;

        /// <summary>
        /// Идентификатор сообщения
        /// </summary>
        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string MessageText { get => _messageText; set { _messageText = value; OnPropertyChanged(); } }

        /// <summary>
        /// Пользователь являющийся отправителем сообщения
        /// </summary>
        public User? FromUser { get => _fromUser; set { _fromUser = value; OnPropertyChanged(); } }

        /// <summary>
        /// Дата и время отправки сообщения
        /// </summary>
        public DateTime SendDateTime { get => _sendDateTime; set { _sendDateTime = value; OnPropertyChanged(); } }

        /// <summary>
        /// Флаг, который хранит информацию: прочитано сообщение или нет
        /// </summary>
        public bool IsRead { get => _isRead; set { _isRead = value; OnPropertyChanged(); } }

        /// <summary>
        /// Флаг, который хранит информацию: принадлежит сообщение текущему пользователю или нет
        /// </summary>
        public bool IsCurrentUserMessage { get => _isCurrentUserMessage; set { _isCurrentUserMessage = value; OnPropertyChanged(); } }

        /// <summary>
        /// Время отправки сообщения
        /// </summary>
        public string Time { get => SendDateTime.ToString("dd-MM-yyyy hh:mm:ss"); }


        public Message()
        {
            Id = 0;
            MessageText = "";
            FromUser = null;
            SendDateTime = DateTime.Now;
            IsRead = false;
            IsCurrentUserMessage = false;
        }

        public Message( string messageText, User? fromUserAccount, DateTime sendDateTime, bool isRead, bool isCurrentUserMessage)
        {
            Id = 0;
            MessageText = messageText;
            FromUser = fromUserAccount;
            SendDateTime = DateTime.Now;
            IsRead = isRead;
            IsCurrentUserMessage = isCurrentUserMessage;
        }
    }
}
