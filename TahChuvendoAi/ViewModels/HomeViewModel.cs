using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TahChuvendoAi.Models;
using TahChuvendoAi.Services;
using TahChuvendoAi.Views;

namespace TahChuvendoAi.ViewModels
{
    [ObservableObject]
    public partial class HomeViewModel
    {
        [ObservableProperty]
        private WeatherForecastModel weatherForecast;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private bool isHistoryLoading;

        private readonly ITahChuvendoAiService tahChuvendoAiService;
        private readonly IOpenWeatherService openWeatherService;

        public HomeViewModel(ITahChuvendoAiService tahChuvendoAiService, IOpenWeatherService openWeatherService)
        {
            this.tahChuvendoAiService = tahChuvendoAiService;
            this.openWeatherService = openWeatherService;
        }

        public ObservableCollection<WeatherHistoryViewModel> Histories { get; set; } = [];

        [RelayCommand]
        public async Task NewWeatherForecast()
        {
            IsLoading = true;

            await Shell.Current.Navigation.PushModalAsync(new CheckingForcast());

            try
            {
                // get lat lng of device
                var location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Best
                });

                // get access token from preferences
                var accessToken = Preferences.Default.Get("AccessToken", "");

                var weatherOtherData = openWeatherService.GetWeatherData(new LatLng(location.Latitude, location.Longitude, location.Altitude));

                WeatherForecast = await tahChuvendoAiService
                    .NovaPrevisaoTempo(accessToken,
                                       new NewWeatherForecastQueryCommand(new LatLng(location.Latitude,
                                                                                     location.Longitude,
                                                                                     location.Altitude), weatherOtherData.Main.Temp, weatherOtherData.Main.Humidity, weatherOtherData.Wind.Speed));

                await LoadHistories();

                await Shell.Current.Navigation.PopModalAsync();
                
                await Shell.Current.GoToAsync($"{nameof(SearchResult)}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        public async Task LoadHistories()
        {
            IsHistoryLoading = true;

            var accessToken = Preferences.Default.Get("AccessToken", "");

            var historyData = await tahChuvendoAiService.Historico(accessToken);

            Histories.Clear();

            historyData.OrderByDescending(x => x.DataHora).Take(5).ToList().ForEach(x =>
            {
                Histories.Add(new WeatherHistoryViewModel
                {
                    DiaDaSemana = x.DataHora.ToString("dddd"),
                    Image = x.Resultado.Image,
                    IntroTitle = x.Resultado.IntroTitle,
                    Temperatura = x.TemperaturaCelsius + "°C"
                });
            });

            IsHistoryLoading = false;
        }
    }
}