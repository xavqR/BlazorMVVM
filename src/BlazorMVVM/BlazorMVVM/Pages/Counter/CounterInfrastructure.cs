using Infrastructure.MVVM;

namespace BlazorMVVM.Pages.Counter
{
    public class CounterInfrastructure
    {
        public readonly CounterVM CounterVM;
        public readonly IVMDataSource CounterVMDataSource;
        public readonly IVMInitializer CounterVMInitializer;

        public CounterInfrastructure(CounterVM counterVM, IVMDataSource counterVMDataSource, IVMInitializer counterVMInitializer)
        {
            ParameterChecker.IsNotNull(counterVM, nameof(counterVM));
            ParameterChecker.IsNotNull(counterVMDataSource, nameof(counterVMDataSource));
            ParameterChecker.IsNotNull(counterVMInitializer, nameof(counterVMInitializer));

            this.CounterVM = counterVM;
            this.CounterVMDataSource = counterVMDataSource;
            this.CounterVMInitializer = counterVMInitializer;
        }
    }
}
