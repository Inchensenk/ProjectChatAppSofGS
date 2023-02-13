using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Authorization : ViewModelBase
    {
        #region Class fields

        /// <inheritdoc cref="Id"/>
        private int _id;

        /// <inheritdoc cref="Login"/>
        private string _login;

        /// <inheritdoc cref="Password"/>
        private string _password;

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
        /// Свойство: Логин
        /// </summary>
        public string Login
        {
            get => _login; 
            set 
            { 
                _login = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Свойство: Пароль
        /// </summary>
        public string Password
        {
            get => _password; 
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        #endregion Class Properties

        #region Class constructors

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Authorization()
        {
            Id = 0;
            Login = null!;
            Password = null!;
        }

        #endregion Class constructors

    }
}
