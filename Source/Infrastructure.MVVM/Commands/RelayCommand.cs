namespace Infrastructure.MVVM
{
    /// <summary>
    /// This class responsibility is to be the base of all those classes that want execute a command.
    /// </summary>
    public class RelayCommand : CommandBase
    {
		#region Attributes

		private readonly Action<object> execute;
		private readonly Predicate<object> canExecute;

        #endregion


        #region Public Methods

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="execute">Execute action.</param>
        /// <param name="canExecute">CanExecute predicate.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
		{
			this.execute = execute;
			this.canExecute = canExecute;
		}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="execute">Execute action.</param>
		public RelayCommand(Action<object> execute)
		{

			this.execute = execute;
		}

        /// <summary>
        /// Validate if command can execute.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        /// <returns></returns>
        public override bool CanExecute(object parameter)
		{
			if (this.canExecute == null)
			{
				return true;
			}
			else
			{
				return this.canExecute(parameter);
			}
		}

        /// <summary>
        /// Execute a command.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        public override void Execute(object parameter)
		{
			this.execute(parameter);
		}

		#endregion
	}
}