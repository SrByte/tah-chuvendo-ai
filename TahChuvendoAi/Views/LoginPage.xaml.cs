using TahChuvendoAi.Auth0;
using TahChuvendoAi.ViewModels;

namespace TahChuvendoAi.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel loginViewModel)
	{
		InitializeComponent();
		BindingContext = loginViewModel;
        loginViewModel.WebViewInstance = WebViewInstance;
	}
}