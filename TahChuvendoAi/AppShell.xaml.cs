using TahChuvendoAi.ViewModels;

namespace TahChuvendoAi
{
    public partial class AppShell : Shell
    {
        public AppShell(LoginViewModel loginViewModel)
        {
            InitializeComponent();
            BindingContext = loginViewModel;
        }
    }
}
