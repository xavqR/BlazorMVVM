using Infrastructure.MVVM;
using Infrastructure.MVVM.Commands;

namespace BlazorMVVM.Pages.Counter
{
    public class CounterFactory : ICounterFactory
    {
        private readonly CounterVM counterVM;
        private readonly IVMDataSource counterVMDataSource;
        private readonly IVMInitializer counterVMInitializer;
        private readonly ICounterVMCommandManager counterVMCommandManager;

        public CounterFactory(CounterVM counterVM, IVMDataSource counterVMDataSource, IVMInitializer counterVMInitializer, ICounterVMCommandManager counterVMCommandManager)
        {
            ParameterChecker.IsNotNull(counterVM, nameof(counterVM));
            ParameterChecker.IsNotNull(counterVMDataSource, nameof(counterVMDataSource));
            ParameterChecker.IsNotNull(counterVMInitializer, nameof(counterVMInitializer));
            ParameterChecker.IsNotNull(counterVMCommandManager, nameof(counterVMCommandManager));

            this.counterVM = counterVM;
            this.counterVMDataSource = counterVMDataSource;
            this.counterVMInitializer = counterVMInitializer;
            this.counterVMCommandManager = counterVMCommandManager;
        }

        public CounterInfrastructure Create()
        {
            ICommand incrementCountCommand = new RelayCommand(this.counterVMCommandManager.IncrementCountExecute);
            this.counterVM.SetCommands(incrementCountCommand);

            this.counterVMDataSource.Start();

            return new CounterInfrastructure(this.counterVM, this.counterVMDataSource, this.counterVMInitializer);
        }
    }
}
