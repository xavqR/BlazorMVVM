
namespace BlazorMVVM.Data
{
    public interface IWeatherForecastService
    {
        Task<List<WeatherForecast>> GetForecastAsync(DateTime startDate);
    }
}