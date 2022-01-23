using Infrastructure.MVVM;

namespace BlazorMVVM.Pages.Counter
{
    public class CounterVMCommandManager : ICounterVMCommandManager
    {
        private readonly CounterModel counterModel;

        public CounterVMCommandManager(CounterModel counterModel)
        {
            ParameterChecker.IsNotNull(counterModel, nameof(counterModel));

            this.counterModel = counterModel;
        }

        public void IncrementCountExecute(object unused)
        {
            this.counterModel.Counter++;
        }
    }
}
