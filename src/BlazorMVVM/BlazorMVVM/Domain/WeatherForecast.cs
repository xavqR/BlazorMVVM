using Infrastructure.MVVM;

namespace BlazorMVVM.Data
{
    public class WeatherForecast : PropertyChangedNotifier
    {   
        private DateTime date;
        private int temperatureC;
        private string summary;

        public DateTime Date
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
                }
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
    }
}