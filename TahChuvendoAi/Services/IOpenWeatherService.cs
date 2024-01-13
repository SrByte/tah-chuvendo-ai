using TahChuvendoAi.Models;

namespace TahChuvendoAi.Services
{
    public interface IOpenWeatherService
    {
        public WeatherDataResponse GetWeatherData(LatLng latLng);
    }
}