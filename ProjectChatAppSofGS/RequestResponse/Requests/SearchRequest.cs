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
    public class SearchRequest : ViewModelBase, IDataErrorInfo
    {
        /// <summary>
        /// Максимальная длина имени
        /// </summary>
        private const int MAX_NAME_LENGTH = 20;

        /// <summary>
        /// Минимальная длинна имени
        /// </summary>
        private const int MIN_NAME_LENGTH = 2;

        /// <summary>
        /// Длинна номера телефона
        /// </summary>
        private const int PHONE_NUMBER_LENGTH = 12;


        /// <inheritdoc cref="FirstName"/>
        private string _firstName;

        /// <inheritdoc cref="PhoneNumber"/>
        private string _phoneNumber;

        /// <inheritdoc cref="Error"/>
        private string _error;

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get => _firstName; set{ _firstName = value; OnPropertyChanged(); } }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get => _phoneNumber; set { _phoneNumber= value; OnPropertyChanged(); } }

        /// <summary>
        /// Ошибка при валидации свойства
        /// </summary>
        public string Error { get => _error; set { _error= value; OnPropertyChanged(); } }

        /// <summary>
        /// Ошибка при валидации номера телефона
        /// </summary>
        public string PhoneNumberError { get; private set; }

        /// <summary>
        /// Ошибка при валидации имени
        /// </summary>
        public string FirstNameError { get; private set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public SearchRequest()
        {
            FirstName= "";
            PhoneNumber = "";
            PhoneNumberError= "";
            FirstNameError = "";
        }




        public string this[string propName] { get { ValidateProperty(propName); return Error; } }

        /// <summary>
        /// Проверка введенного имени на корректность
        /// </summary>
        private void ValidateFirstName()
        {
            Regex regex = new Regex(@"^\w+");

            if (!String.IsNullOrEmpty(FirstName) && FirstName.Length < MIN_NAME_LENGTH)
            {
                Error = "Имя должно быть не меньше 2х символов";
                FirstNameError = Error;
            }

            else if (!String.IsNullOrEmpty(FirstName) && !regex.IsMatch(FirstName))
            {
                Error = "Недопустимые символы в имени";
                FirstNameError = Error;
            }

            else if (FirstName.Length > MAX_NAME_LENGTH)
            {
                Error = "Имя не должно превышать 50ти символов";
                FirstNameError = Error;
            }

            else
            {
                Error = "";
                FirstNameError = "";
            }

        }


        /// <summary>
        /// Проверка введенного номера телефона на корректность
        /// </summary>
        private void ValidatePhoneNumber()
        {
            Regex regex = new Regex(@"^\+7\d{10}");

            if (!String.IsNullOrEmpty(PhoneNumber) && (!regex.IsMatch(PhoneNumber) || PhoneNumber.Length > PHONE_NUMBER_LENGTH))
            {
                Error = "Телефон должен начинаться с +7\nи не превышать 12 символов";
                PhoneNumberError = Error;
            }

            else
            {
                Error = "";
                PhoneNumberError = "";
            }
        }

        /// <summary>
        /// Проверка свойства на корректность
        /// </summary>
        /// <param name="propName"></param>
        private void ValidateProperty(string propName)
        {
            switch (propName)
            {
                case nameof(FirstName):
                    ValidateFirstName();
                    break;

                case nameof(PhoneNumber):
                    ValidatePhoneNumber();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Содержит ли запрос ошибку?
        /// </summary>
        /// <returns>true - если содержит, false - если нет</returns>
        public bool HasNotErrors()
        {
            return PhoneNumberError == "" && FirstNameError == "" && (PhoneNumber != "" || FirstName != "");
        }


        /// <summary>
        /// Получить текст ошибки запроса
        /// </summary>
        /// <returns>текст ошибки запроса</returns>
        public string GetError()
        {
            if (PhoneNumberError != "")
                return PhoneNumberError;

            else if (FirstNameError != "")
                return FirstNameError;

            return "Заполните одно из полей поиска";
        }
    }
}
