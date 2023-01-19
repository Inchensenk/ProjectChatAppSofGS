using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectChatAppSofGS.Commands
{
    /// <summary>
    /// Базовый абстрактный класс комманд
    /// </summary>
    public abstract class CommandBase : ICommand
    {

        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Метод сообщает может ли комманда выпольниться
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>Если метод вернет false то кнопка в представлении будет отключена.
        /// Затем, если по каим-то причинам значение метода меняется, 
        /// то вызывается CanExecuteChanged и повторно вызывается этот метод,
        /// чтобы сново определить может ли метод выполняться</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual bool CanExecute(object? parameter)/*для переопределения метода наследниками делаем его виртуальным*/
        {
            return true;
        }

        /// <summary>
        /// Метот исполняется если после нажатия на кнопку, к которой он будет привязан, метод CanExecute вернет true
        /// </summary>
        /// <param name="parameter"></param>
        /// <exception cref="NotImplementedException"></exception>
        public abstract void Execute(object? parameter);/*делаем метот абстрактным, чтобы наследники класса CommandBase обязательно его реализовали*/

        /// <summary>
        /// Метод дает чистый способ вызвать метод CanExecuteChanged
        /// </summary>
        protected void OnCanExecuteChanged()
        {
            //передаем в метод отправителя и несколько пустых аргументов события
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }


    }
}
