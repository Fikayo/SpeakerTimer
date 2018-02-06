using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChurchTimer.Presentation.ViewModels
{
    public class CommandHandler : ICommand
    {
        private Action action;
        private bool canExecute;
        private Func<bool> canExecuteFunc;

        public CommandHandler(Action action)
          : this(action, true)
        {
        }

        public CommandHandler(Action action, bool canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public CommandHandler(Action action, Func<bool> canExecuteFunc)
        {
            this.action = action;
            this.canExecuteFunc = canExecuteFunc;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (this.canExecuteFunc != null)
            {
                return this.canExecuteFunc();
            }

            return this.canExecute;
        }

        public void Execute(object parameter)
        {
            this.action();
        }
    }
}
