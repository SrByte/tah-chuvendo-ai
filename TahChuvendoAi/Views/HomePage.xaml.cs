using Microsoft.Maui.Controls;

namespace TahChuvendoAi.Views
{
    public partial class HomePage : ContentPage
    {
        private string[] items = { "ensolarado.png", "promocao2.png", "promocao3.png", "promocao1.png" };
        public HomePage()
        {
            InitializeComponent();
        }

        private async void  Button_Clicked(object sender, EventArgs e)
        {
          await Navigation.PushModalAsync(new CheckingForcast(),true);
        }
    }
}