using Infrastructure.MVVM;
using System.ComponentModel;

namespace BlazorMVVM.Pages.Counter
{
    public class CounterVMDataSource : IVMDataSource
    {
        private bool isStarted;
        private readonly CounterVM counterVM;
        private readonly CounterModel counterModel;      

        public CounterVMDataSource(CounterVM counterVM, CounterModel counterModel)
        {
            ParameterChecker.IsNotNull(counterVM, nameof(counterVM));
            ParameterChecker.IsNotNull(counterModel, nameof(counterModel));

            this.counterVM = counterVM;
            this.counterModel = counterModel;
        }

        public void Start()
        {
            if (!this.isStarted)
            {
                this.counterVM.PropertyChanged += this.OnCounterVMPropertyChanged;
                this.counterModel.PropertyChanged += this.OnCounterModelPropertyChanged;
                this.isStarted = true;
            }
            else
            {
                throw new Exception("CounterVMDataSource is already started");
            }        
        }

        private void OnCounterVMPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(counterVM.CurrentCounter):
                    this.counterModel.Counter = counterVM.CurrentCounter;
                    break;
            }
        }

        private void OnCounterModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(counterModel.Counter):
                    this.counterVM.CurrentCounter = counterModel.Counter;
                    break;
            }
        }
    }
}
