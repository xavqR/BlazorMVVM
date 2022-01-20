using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MVVM.Commands
{
    public interface ICommand
    {
        //
        // Resumen:
        //     Occurs when changes occur that affect whether or not the command should execute.
        event EventHandler? CanExecuteChanged;

        //
        // Resumen:
        //     Defines the method that determines whether the command can execute in its current
        //     state.
        //
        // Parámetros:
        //   parameter:
        //     Data used by the command. If the command does not require data to be passed,
        //     this object can be set to null.
        //
        // Devuelve:
        //     true if this command can be executed; otherwise, false.
        bool CanExecute(object? parameter);

        //
        // Resumen:
        //     Defines the method to be called when the command is invoked.
        //
        // Parámetros:
        //   parameter:
        //     Data used by the command. If the command does not require data to be passed,
        //     this object can be set to null.
        void Execute(object? parameter);
    }
}
