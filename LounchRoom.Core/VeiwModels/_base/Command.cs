using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LounchRoom.Core.VeiwModels
{
    public class Command : ICommand
    {
        private Action execute;
        public Command(Action ex)
        {
            execute = ex;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return execute != null;
        }

        public void Execute(object parameter)
        {
            execute?.Invoke();
        }
    }
}
