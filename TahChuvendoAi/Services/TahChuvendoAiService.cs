﻿using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using TahChuvendoAi.Models;

namespace TahChuvendoAi.Services
{
    public class TahChuvendoAiService : ITahChuvendoAiService
    {
        private readonly HttpClient _httpClient;

        public TahChuvendoAiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://tahchuvendoai-apim.azure-api.net")
            };
        }

        public async Task<WeatherForecastModel> NovaPrevisaoTempo(string token, NewWeatherForecastQueryCommand request)
        {
            // Create the request URI
            var requestUri = "/tahchuvendoai/api/Previsao";

            requestUri += $"?LatLng.Latitude={request.LatLng.Latitude}&LatLng.Longitude={request.LatLng.Longitude}&Altitude={request.LatLng.Altitude}&TemperaturaCelsius={request.TemperaturaCelsius}&Umidade={request.Umidade}&VelocidadeVento={request.VelocidadeVento}";

            // Add the token to the request headers
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Send the POST request
            var response = await _httpClient.GetAsync(requestUri);

            // Ensure the response is successful
            response.EnsureSuccessStatusCode();

            // Deserialize and return the response content as WeatherForecastModel
            var result = await JsonSerializer.DeserializeAsync<WeatherForecastModel>(
                await response.Content.ReadAsStreamAsync());

            return result;
        }

        public async Task<List<WeatherHistory>> Historico(string token)
        {
            // Create the request URI
            var requestUri = "/tahchuvendoai/api/historico";

            // Add the token to the request headers
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Send the POST request
            var response = await _httpClient.GetAsync(requestUri);

            // Ensure the response is successful
            response.EnsureSuccessStatusCode();

            // Deserialize and return the response content as WeatherForecastModel
            var result = await JsonSerializer.DeserializeAsync<List<WeatherHistory>>(
                await response.Content.ReadAsStreamAsync());

            return result;
        }
    }
}