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
        public int Id
        {
            get => _id; 
            set { _id = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Свойство: Номер отправителя сообщения
        /// </summary>
        public string FromNumber
        {
            get => _fromNumber; 
            set { _fromNumber = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Свойство: Текст сообщения
        /// </summary>
        public string MessageText
        {
            get => _messageText;
            set { _messageText = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Свойство: Время отправки сообщения
        /// </summary>
        public DateTime SendDateTime
        {
            get => _sendDateTime;
            set { _sendDateTime = value; OnPropertyChanged();}
        }

        public bool IsCurrentUserMessage
        {
            get => _isCurrentUserMessage;
            set { _isCurrentUserMessage = value; OnPropertyChanged(); }
        }

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
        #endregion Сlass constructors
    }
}
