using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using mvvmClient.ViewModel;

namespace MVVM.Commands
{
    public class RelayCommand : ICommand
    {
        public Action<object> ExecuteCallback { get; set; }
        public Func<object, bool> CanExecuteCallback { get; set; }

        public RelayCommand(Action<object> executeCallback, Func<object, bool> canExecuteCallback)
        {
            ExecuteCallback = executeCallback;
            CanExecuteCallback = canExecuteCallback;
            CommandManager.RequerySuggested += delegate { OnCanExecuteChanged(); };
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteCallback(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteCallback(parameter);
        }

        public void Invatidate()
        {
            OnCanExecuteChanged();
        }

        public event EventHandler CanExecuteChanged;

        protected virtual void OnCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
