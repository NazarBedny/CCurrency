using System;
using System.Windows.Input;

namespace CCurrency.ViewModel
{
    public class DelegateCommand : ICommand
    {
        private Action<object> execute;
      
        private Func<object, bool> canExecute;
        private Action<object, ExecutedRoutedEventArgs> executeEvent;

        public DelegateCommand(Action<object> execute,Func<object, bool> canExecute = null)
        {
            
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public DelegateCommand( Action<object, ExecutedRoutedEventArgs> executeEvent,Func<object, bool> canExecute = null)
        {
            
            this.canExecute = canExecute;
            this.executeEvent = executeEvent;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
