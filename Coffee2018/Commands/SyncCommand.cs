using System;
using System.Windows.Input;

namespace Coffee2018.Commands
{
    public class SyncCommand : ICommand
    {
        private readonly Action _execute;

        public SyncCommand(Action execute)
        {
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {

            return true;
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke();
        }
    }
}
