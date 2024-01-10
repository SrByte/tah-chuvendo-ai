using Microsoft.Maui.Controls;
using TahChuvendoAi.Models;

namespace TahChuvendoAi.Views
{
    public partial class HomePage : ContentPage
    {
        private string[] items = { "ensolarado.png", "promocao2.png", "promocao3.png", "promocao1.png" };
        public HomePage()
        {
            InitializeComponent();
            var Items = new List<WeatherHistory>
            {
                new WeatherHistory { IntroTitle="Manhã Ensolarada", Image="ensolarado.png"},
                new WeatherHistory { IntroTitle="Tarde Chuvosa", Image="promocao1.png"},
                new WeatherHistory { IntroTitle="Tempestade de Fogo", Image="promocao3.png"},
                new WeatherHistory { IntroTitle="Noite de Luar", Image="promocao2.png"},
                new WeatherHistory { IntroTitle="Tarde de Dilúvio", Image="promocao3.png"}
            };
            CarouselView.ItemsSource = Items;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CheckingForcast(), true);
            // await Navigation.PopModalAsync();

        }

    }
}