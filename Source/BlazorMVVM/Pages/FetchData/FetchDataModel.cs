using BlazorMVVM.Data;
using System.Collections.ObjectModel;

namespace BlazorMVVM.Pages.FetchData
{
    public class FetchDataModel
    {
        private readonly ObservableCollection<WeatherForecast> forecasts;

        public ObservableCollection<WeatherForecast> Forecasts
        {
            get
            {
                return this.forecasts;
            }
        }

        public FetchDataModel()
        {
            forecasts = new ObservableCollection<WeatherForecast>();
        }
    }
}
