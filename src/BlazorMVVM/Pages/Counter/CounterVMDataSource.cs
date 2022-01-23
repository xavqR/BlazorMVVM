using Infrastructure.MVVM;
using System.ComponentModel;

namespace BlazorMVVM.Pages.Counter
{
    public class CounterVMDataSource : IVMDataSource, IDisposable
    {
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
            this.counterVM.PropertyChanged += this.OnCounterVMPropertyChanged;
            this.counterModel.PropertyChanged += this.OnCounterModelPropertyChanged;
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

        #region IDisposable

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                    this.counterVM.PropertyChanged -= this.OnCounterVMPropertyChanged;
                    this.counterModel.PropertyChanged -= this.OnCounterModelPropertyChanged;
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~CounterVMDataSource()
        {
            Dispose(false);
        }

        #endregion
    }
}
