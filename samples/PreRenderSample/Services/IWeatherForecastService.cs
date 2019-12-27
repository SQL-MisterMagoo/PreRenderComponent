using System;
using System.Threading.Tasks;

namespace PreRenderSample.Services
{
    public interface IWeatherForecastService
    {

        Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
    }
}
