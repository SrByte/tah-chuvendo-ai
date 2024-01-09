namespace TahChuvendoAi.Views;

public partial class CheckingForcast : ContentPage
{
	public CheckingForcast()
	{
		InitializeComponent();
	}
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await Task.Delay(100);
        imgLoader.IsAnimationPlaying = true;
    }
}