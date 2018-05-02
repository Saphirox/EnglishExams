using System;
using System.Windows.Input;

namespace EnglishExams.Infrastructure
{
    /// <inheritdoc />
    /// <summary>
    /// Custom realization of ICommand contract -&gt; help to execute element events
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _action;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action action, Func<bool> canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute is null)
                return true;

            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}