using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using TahChuvendoAi.Auth0;
using TahChuvendoAi.Services;
using TahChuvendoAi.ViewModels;
using TahChuvendoAi.Views;

namespace TahChuvendoAi
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                 .UseMauiCommunityToolkit();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IOpenWeatherService, OpenWeatherService>();
            builder.Services.AddTransient<SearchResultViewModel>();
            builder.Services.AddTransient<SearchResult>();
            builder.Services.AddSingleton<ITahChuvendoAiService, TahChuvendoAiService>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<IUsuarioService, UsuarioService>();
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<LoginPage>();

            builder.Services.AddSingleton(new Auth0Client(new()
            {
                Domain = "dev-13evj4mwojoazag7.us.auth0.com",
                ClientId = "R80qTeu5N7Pf5brl5w2hRKcAyrjSbYNP",
                Audience = "https://localhost:44386",
                Scope = "openid profile",
                #if WINDOWS
                    RedirectUri = "http://localhost/callback"
                #else
                    RedirectUri = "myapp://callback"
                #endif
            }));

            return builder.Build();
        }
    }
}
