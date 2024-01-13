using TahChuvendoAi.ViewModels;
using TahChuvendoAi.Views;

namespace TahChuvendoAi
{
    public partial class AppShell : Shell
    {
        public AppShell(LoginViewModel loginViewModel)
        {
            InitializeComponent();
            BindingContext = loginViewModel;

            Routing.RegisterRoute(nameof(SearchResult), typeof(SearchResult));
        }
    }
}
