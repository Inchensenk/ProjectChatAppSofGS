using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Client.RequestResponse.Requests
{
    public class SignUpRequest : SignInRequest
    {
        /// <summary>
        /// Максимальная длина имени
        /// </summary>
        private const int MAX_FIRST_NAME_LENGTH = 20;

        /// <summary>
        /// Минимальная длинна имени
        /// </summary>
        private const int MIN_FIRST_NAME_LENGTH = 2;

        /// <inheritdoc cref="RepeatedPassword"/>
        private string _repeatedPassword;

        /// <inheritdoc cref="FirstName"/>
        private string _firstName;

        /// <summary>
        /// Повторяющий пароль
        /// </summary>
        public string RepeatedPassword { get => _repeatedPassword; set { _repeatedPassword = value; OnPropertyChanged(); } }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get => _firstName;set { _firstName = value; OnPropertyChanged();} }

        /// <summary>
        /// Ошибка в имени в запросе
        /// </summary>
        public string FirstNameError { get; protected set; }

        /// <summary>
        /// Ошика в повторяющемся пароле в запросе
        /// </summary>
        public string RepeatedPasswordError { get; protected set; }

        /// <summary>
        /// Запрос по умолчанию
        /// </summary>
        public SignUpRequest() : base()
        {
            FirstName = "";
            RepeatedPassword = "";
            FirstNameError = "";
            RepeatedPasswordError = "";
        }



        /// <summary>
        /// Получить ошибку запроса
        /// </summary>
        /// <returns>Ошибка запроса</returns>
        public override string GetError()
        {
            if (base.GetError() != "")
                return base.GetError();

            else if (RepeatedPasswordError != "")
                return RepeatedPasswordError;

            return FirstNameError;
        }

        /// <summary>
        /// Есть ошибка в запросе?
        /// </summary>
        /// <returns>true - если есть, false - если нет</returns>
        public override bool HasNotErrors()
        {
            return base.HasNotErrors() 
            && RepeatedPasswordError == "" 
            && FirstNameError == "";
        }

        /// <summary>
        /// Проверить на корретность имя
        /// </summary>
        private void ValidateFirstName()
        {
            Regex regex = new Regex(@"^\w+");

            if (String.IsNullOrEmpty(FirstName))
            {
                Error = "Имя должно быть не меньше 2х символов";
                FirstNameError = Error;
            }

            else if (!regex.IsMatch(FirstName))
            {
                Error = "Недопустимые символы";
                FirstNameError = Error;
            }

            else if (FirstName.Length > MAX_FIRST_NAME_LENGTH)
            {
                Error = "Имя не должно превышать 50ти символов";
                FirstNameError = Error;
            }

            else if (FirstName.Length < MIN_FIRST_NAME_LENGTH)
            {
                Error = "Имя должно быть не меньше 2х символов";
                FirstNameError = Error;
            }

            else
            {
                Error = "";
                FirstNameError = "";
            }
        }

        /// <summary>
        /// Проверить на корректность повторяющийся пароль
        /// </summary>
        protected void ValidateRepeatedPassword()
        {
            Regex regex = new Regex(@"^\w{6}");

            if (!regex.IsMatch(RepeatedPassword))
            {
                Error = "Пароль может состоять из заглавных и строчных букв, а также цифр";
                RepeatedPasswordError = Error;
            }

            else if (RepeatedPassword.Length > MAX_LENGTH_OF_PASSWORD)
            {
                Error = "Пароль должен содержать не больше 10ти символов";
                RepeatedPasswordError = Error;
            }

            else if (RepeatedPassword.Length < MIN_LENGTH_OF_PASSWORD)
            {
                Error = "Пароль должен содержать не меньше 6ти символов";
                RepeatedPasswordError = Error;
            }

            else if (Password != "" && Password != RepeatedPassword)
            {
                Error = "Пароли должны совпадать";
                RepeatedPasswordError = Error;
            }

            else
            {
                Error = "";
                RepeatedPasswordError = "";
            }
        }

        /// <summary>
        /// Проверить на корректность пароль
        /// </summary>
        protected override void ValidatePassword()
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

            else if (RepeatedPassword != "" && Password != RepeatedPassword)
            {
                Error = "Пароли должны совпадать";
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
        protected override void ValidateProperty(string propName)
        {
            base.ValidatePhoneNumber();

            switch (propName)
            {
                case nameof(FirstName):
                    ValidateFirstName();
                    break;

                case nameof(Password):
                    ValidatePassword();
                    break;

                case nameof(RepeatedPassword):
                    ValidateRepeatedPassword();
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
        public override string this[string propName]
        {
            get
            {
                ValidateProperty(propName);

                return Error;
            }
        }

    }
}
