using Infrastructure.MVVM;

namespace BlazorMVVM.Pages.Counter
{
    public class CounterVMInitializer : IVMInitializer
    {
        private readonly CounterVM counterVM;

        public CounterVMInitializer(CounterVM counterVM)
        {
            ParameterChecker.IsNotNull(counterVM, nameof(counterVM));

            this.counterVM = counterVM;
        }

        public void Initialize()
        {
            this.counterVM.CurrentCounter = 10;
        }
    }
}
