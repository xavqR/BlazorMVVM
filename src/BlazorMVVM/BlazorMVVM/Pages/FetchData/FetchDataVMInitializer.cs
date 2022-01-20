using BlazorMVVM.Data;
using BlazorMVVM.Pages.FetchData;
using Infrastructure.MVVM;

namespace BlazorMVVM.Pages.Counter
{
    public class FetchDataVMInitializer : IVMInitializer
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

        public async void Initialize()
        {
            List<WeatherForecast> forecasts = await this.weatherForecastService.GetForecastAsync(DateTime.Now);
            fetchDataModel.Forecasts.Clear();
            forecasts.ForEach(f => fetchDataModel.Forecasts.Add(f));            
        }
    }
}
