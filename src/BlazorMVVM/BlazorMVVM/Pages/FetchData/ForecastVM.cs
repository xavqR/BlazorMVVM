using BlazorMVVM.Data;
using Infrastructure.MVVM;

namespace BlazorMVVM.Pages.FetchData
{
    public class ForecastVM : PropertyChangedNotifier
    {
        private string date;
        private int temperatureC;
        private string summary;
        public readonly WeatherForecast Model;

        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                if (this.date != value)
                {
                    this.date = value;
                    this.OnPropertyChanged(nameof(this.Date));
                }
            }
        }

        public int TemperatureC
        {
            get
            {
                return this.temperatureC;
            }
            set
            {
                if (this.temperatureC != value)
                {
                    this.temperatureC = value;
                    this.OnPropertyChanged(nameof(this.TemperatureC));
                    this.OnPropertyChanged(nameof(this.TemperatureF));
                }
            }
        }

        public int TemperatureF
        {
            get
            {
                return 32 + (int)(this.TemperatureC / 0.5556);
            }
        }

        public string Summary
        {
            get
            {
                return this.summary;
            }
            set
            {
                if (this.summary != value)
                {
                    this.summary = value;
                    this.OnPropertyChanged(nameof(this.Summary));
                }
            }
        }

        public ForecastVM(WeatherForecast model)
        {
            ParameterChecker.IsNotNull(model, nameof(model));   

            this.Model = model;
        }
    }
}
