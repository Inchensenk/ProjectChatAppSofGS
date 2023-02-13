using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class User : ViewModelBase
    {

        #region Class fields
        /// <inheritdoc cref="Id"/>
        private int _id;

        /// <inheritdoc cref="NickName"/>
        private string _nickName;

        /// <inheritdoc cref="PhoneNumber"/>
        private string _phoneNumber;

        /// <inheritdoc cref="FirstName"/>
        private string _firstName;

        /// <inheritdoc cref="LastName"/>
        private string _lastName;


        #endregion

        #region Class properties
        /// <summary>
        /// Свойство: Идентификатор
        /// </summary>
        public int Id 
        {
            get => _id;
            set
            {
                _id= value;
                OnPropertyChanged();
            } 
        }

        /// <summary>
        /// Свойство: Ник
        /// </summary>
        public string NickName
        {
            get => _nickName; 
            set
            {
                _nickName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Свойство: Имя
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName= value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Свойство: Фамилия
        /// </summary>
        public string LastName
        {
            get => _lastName; 
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Свойство: Номер телефона
        /// </summary>
        public string PhoneNumber
        {
            get => _phoneNumber; 
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Сlass constructors
        public User()
        {
            Id = 0;
            NickName = null!;
            FirstName = null!;
            LastName = null!;
            PhoneNumber = null!;
        }
        #endregion
    }
}
