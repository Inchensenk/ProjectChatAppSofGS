using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Client.RequestResponse.Requests
{
    /// <summary>
    /// Запрос на вход в мессенджер
    /// </summary>
    public class SignInRequest : ViewModelBase, IDataErrorInfo
    {
        /// <summary>
        /// Максимальная длина пароля
        /// </summary>
        protected const int MAX_LENGTH_OF_PASSWORD = 14;

        /// <summary>
        /// Минимальная длина пароля
        /// </summary>
        protected const int MIN_LENGTH_OF_PASSWORD = 8;

        /// <summary>
        /// Длинна номера телефона
        /// </summary>
        private const int PHONE_NUMBER_LENGTH = 12;


        /// <inheritdoc cref="PhoneNumber"/>
        private string _phoneNumber;

        /// <inheritdoc cref="Password"/>
        private string _password;

        /// <inheritdoc cref="Error"/>
        private string _error;

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; OnPropertyChanged(); } }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }

        /// <summary>
        /// Ошибка при валидации свойства
        /// </summary>
        public virtual string Error { get => _error; set { _error = value; OnPropertyChanged(); } }

        /// <summary>
        /// Ошибка при пооверке на корректность телефона
        /// </summary>
        public string PhoneNumberError { get; protected set; }

        /// <summary>
        /// Ошибка при проверке на корректность пароля
        /// </summary>
        public string PasswordError { get; protected set; }


        public SignInRequest()
        {
            PhoneNumber = "";
            Password = "";
            Error = "";
            PhoneNumberError = "";
            PasswordError = "";
        }













        /// <summary>
        /// Проверить на корректность номер телефона
        /// </summary>
        protected void ValidatePhoneNumber()
        {
            Regex regex = new Regex(@"^\+7\d{10}");

            //Error = "";

            if (!regex.IsMatch(PhoneNumber))
            {
                Error = "Телефон должен начинаться с +7 и далее состоять из 10 цифр";
                PhoneNumberError = Error;
            }

            else if (PhoneNumber.Length != PHONE_NUMBER_LENGTH)
            {
                Error = "Телефон должнен состоять из 12 символов всего";
                PhoneNumberError = Error;
            }

            else
            {
                Error = "";
                PhoneNumberError = "";
            }
        }

        /// <summary>
        /// Проверить на корректность пароль
        /// </summary>
        protected virtual void ValidatePassword()
        {
            Regex regex = new Regex(@"^\w{6}");

            if (!regex.IsMatch(Password))
            {
                Error = "Пароль может состоять из заглавных и строчных букв, а также цифр";
                PasswordError = Error;
            }

            else if (Password.Length > MAX_LENGTH_OF_PASSWORD)
            {
                Error = "Пароль должен содержать не больше 10ти символов";
                PasswordError = Error;
            }

            else if (Password.Length < MIN_LENGTH_OF_PASSWORD)
            {
                Error = "Пароль должен содержать не меньше 6ти символов";
                PasswordError = Error;
            }

            else
            {
                Error = "";
                PasswordError = "";
            }
        }

        /// <summary>
        /// Проверить все свойства класса на корректность
        /// </summary>
        /// <param name="propName">Имя свойства</param>
        protected virtual void ValidateProperty(string propName)
        {
            switch (propName)
            {
                case nameof(PhoneNumber):
                    ValidatePhoneNumber();
                    break;

                case nameof(Password):
                    ValidatePassword();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Получает сообщение об ошибке для свойства с заданным именем по индексатору
        /// </summary>
        /// <param name="propName">Имя свойства</param>
        /// <returns></returns>
        public virtual string this[string propName]
        {
            get
            {
                ValidateProperty(propName);

                return Error;
            }
        }

        /// <summary>
        /// Запрос содержит ошибку?
        /// </summary>
        /// <returns>true - если содержит, false - если нет</returns>
        public virtual bool HasNotErrors()
        {
            return PhoneNumberError == "" && PasswordError == "";
        }

        /// <summary>
        /// Получить ошибку запроса
        /// </summary>
        /// <returns>Ошибка запроса</returns>
        public virtual string GetError()
        {
            if (PhoneNumberError != "")
                return PhoneNumberError;

            return PasswordError;
        }

    }
}
