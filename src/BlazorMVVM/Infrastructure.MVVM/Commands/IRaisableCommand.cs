using Infrastructure.MVVM.Commands;

namespace Infrastructure.MVVM
{
	/// <summary>
	/// Defines the implementation of <see cref="IRaisableCommand"/>.
	/// </summary>
	public interface IRaisableCommand : ICommand
	{
		/// <summary>
		/// Raise command can execute.
		/// </summary>
		void RaiseCanExecute();
	}
}
