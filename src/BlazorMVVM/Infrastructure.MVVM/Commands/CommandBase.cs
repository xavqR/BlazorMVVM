using System.Diagnostics;

namespace Infrastructure.MVVM
{
    /// <summary>
    /// This class responsibility is to manage the base logic of the CanExecuteChanged command event.
    /// </summary>
    public abstract class CommandBase : IRaisableCommand
    {
        #region Events

        /// <summary>
        /// Informs that a command CanExecute has changed its value.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Raise command can execute.
        /// </summary>
        public void RaiseCanExecute()
        {
            this.OnCanExecuteChanged();
        }

        /// <summary>
        /// Informs that a command CanExecute has changed its value.
        /// </summary>
        protected virtual void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChanged;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        #region ICommand Members

        [DebuggerStepThrough]
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        #endregion
    }
}