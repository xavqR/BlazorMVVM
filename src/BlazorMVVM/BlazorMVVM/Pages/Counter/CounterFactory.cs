using Infrastructure.MVVM;
using Infrastructure.MVVM.Commands;

namespace BlazorMVVM.Pages.Counter
{
    public class CounterFactory : IFactory
    {
        private readonly CounterVM counterVM;
        private readonly ICounterVMCommandManager counterVMCommandManager;
        private readonly IVMDataSource counterVMDataSource;

        public bool IsCreated { get; private set; }

        public CounterFactory(CounterVM counterVM, ICounterVMCommandManager counterVMCommandManager, IVMDataSource counterVMDataSource)
        {
            ParameterChecker.IsNotNull(counterVM, nameof(counterVM));
            ParameterChecker.IsNotNull(counterVMCommandManager, nameof(counterVMCommandManager));
            ParameterChecker.IsNotNull(counterVMDataSource, nameof(counterVMDataSource));

            this.counterVM = counterVM;
            this.counterVMCommandManager = counterVMCommandManager;
            this.counterVMDataSource = counterVMDataSource;
        }

        public void Create()
        {
            if (!this.IsCreated)
            {
                ICommand incrementCountCommand = new RelayCommand(this.counterVMCommandManager.IncrementCountExecute);
                this.counterVM.SetCommands(incrementCountCommand); 
                
                this.counterVMDataSource.Start();
                this.IsCreated = true;
            } 
            else
            {
                throw new Exception("CounterInfrastructureStarter is already started");
            }
        }
    }
}
