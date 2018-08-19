using System;
using System.Windows.Input;

namespace mvvmClient.Commands
{

    /// <summary>
    /// Hilfsklasse für MVVM-Commands
    /// </summary>
    public class ActionCommand : ICommand
    {
        public ActionCommand(Action action)
        {
            this.action = action;
            this.IsEnabled = true;
        }

        private bool isEnabled;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                if (CanExecuteChanged != null) CanExecuteChanged(this, EventArgs.Empty);
            }
        }
        private Action action;

        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            action();
        }

    }
}
