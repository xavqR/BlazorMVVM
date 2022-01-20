using BlazorMVVM.Data;
using BlazorMVVM.Pages.FetchData;
using Infrastructure.MVVM;
using System.Collections.Specialized;

namespace BlazorMVVM.Pages.Counter
{
    public class FetchDataVMDataSource : IVMDataSource, IDisposable
    {
        private readonly FetchDataVM fetchDataVM;
        private readonly FetchDataModel fetchDataModel;

        public FetchDataVMDataSource(FetchDataVM fetchDataVM, FetchDataModel fetchDataModel)
        {
            ParameterChecker.IsNotNull(fetchDataVM, nameof(fetchDataVM));
            ParameterChecker.IsNotNull(fetchDataModel, nameof(fetchDataModel));

            this.fetchDataVM = fetchDataVM;
            this.fetchDataModel = fetchDataModel;
        }

        public void Start()
        {
            this.fetchDataModel.Forecasts.CollectionChanged += this.OnForecastsCollectionChanged; 
        }

        private void OnForecastsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (WeatherForecast forecast in e.NewItems.OfType<WeatherForecast>())
                    {
                        this.fetchDataVM.ForecastsVM.Add(new ForecastVM(forecast) { Date = forecast.Date.ToShortDateString(), TemperatureC = forecast.TemperatureC, Summary = forecast.Summary });
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    this.fetchDataVM.ForecastsVM.Clear();
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
                    this.fetchDataModel.Forecasts.CollectionChanged -= this.OnForecastsCollectionChanged;
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~FetchDataVMDataSource()
        {
            Dispose(false);
        }

        #endregion
    }
}
