using TahChuvendoAi.Models;

namespace TahChuvendoAi.Services
{
    public interface ITahChuvendoAiService
    {
        Task<WeatherForecastModel> NovaPrevisaoTempo(string token, NewWeatherForecastQueryCommand request);
        Task<List<WeatherHistory>> Historico(string token);
    }
}