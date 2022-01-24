using BlazorMVVM.Data;
using BlazorMVVM.Pages.FetchData;
using Infrastructure.MVVM;

namespace BlazorMVVM.Pages.Counter
{
    public class FetchDataVMInitializer : IVMInitializerAsync
    {
        private readonly FetchDataModel fetchDataModel;
        private readonly IWeatherForecastService weatherForecastService;

        public FetchDataVMInitializer(FetchDataModel fetchDataModel, IWeatherForecastService weatherForecastService)
        {
            ParameterChecker.IsNotNull(fetchDataModel, nameof(fetchDataModel));
            ParameterChecker.IsNotNull(weatherForecastService, nameof(weatherForecastService));

            this.fetchDataModel = fetchDataModel;
            this.weatherForecastService = weatherForecastService;
        }

        public async Task InitializeAsync(CancellationToken cancellationToken)
        {
            ParameterChecker.IsNotNull(cancellationToken, nameof(cancellationToken));

            fetchDataModel.Forecasts.Clear(); 
            List<WeatherForecast> forecasts = this.weatherForecastService.GetForecastAsync(DateTime.Now).Result;      
            if (!cancellationToken.IsCancellationRequested)
            {
                forecasts.ForEach(f => fetchDataModel.Forecasts.Add(f));
            }          
        }
    }
}
