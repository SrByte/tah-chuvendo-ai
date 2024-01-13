using System.Text.Json;
using TahChuvendoAi.Models;

namespace TahChuvendoAi.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly HttpClient _httpClient;

        public OpenWeatherService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.openweathermap.org")
            };
        }

        public WeatherDataResponse GetWeatherData(LatLng latLng)
        {
            var url = $"/data/2.5/weather?lat={latLng.Latitude}&lon={latLng.Longitude}&appid=9791673c037bd3d674ec6cfbe58e0066&units=metric";
            var response = _httpClient.GetAsync(url).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var weatherDataResponse = JsonSerializer.Deserialize<WeatherDataResponse>(content);

            return weatherDataResponse;
        }
    }
}