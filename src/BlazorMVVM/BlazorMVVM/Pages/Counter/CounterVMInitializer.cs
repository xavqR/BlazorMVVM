using Infrastructure.MVVM;

namespace BlazorMVVM.Pages.Counter
{
    public class CounterVMInitializer : IVMInitializer
    {
        private readonly CounterModel counterModel;

        public CounterVMInitializer(CounterModel counterModel)
        {
            ParameterChecker.IsNotNull(counterModel, nameof(counterModel));

            this.counterModel = counterModel;
        }

        public void Initialize()
        {
            this.counterModel.Counter = 10;
        }
    }
}
