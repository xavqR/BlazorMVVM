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

        public CounterFactory(CounterVM counterVM, IResolver<IVMDataSource> dataSourceResolver, IVMInitializer initializerResolver, ICounterVMCommandManager counterVMCommandManager)
        {
            ParameterChecker.IsNotNull(counterVM, nameof(counterVM));
            ParameterChecker.IsNotNull(dataSourceResolver, nameof(dataSourceResolver));
            ParameterChecker.IsNotNull(initializerResolver, nameof(initializerResolver));
            ParameterChecker.IsNotNull(counterVMCommandManager, nameof(counterVMCommandManager));

            this.counterVM = counterVM;
            this.counterVMDataSource = dataSourceResolver.Resolve(nameof(CounterVMDataSource));
            this.counterVMInitializer = initializerResolver; 
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
