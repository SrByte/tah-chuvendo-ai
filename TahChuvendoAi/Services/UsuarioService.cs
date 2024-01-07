using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using TahChuvendoAi.Auth0;

namespace TahChuvendoAi.Services;

public class UsuarioService(Auth0Client auth0Client) : IUsuarioService
{
    public async Task<LoginResult> LoginAsync() => await auth0Client.LoginAsync();

    public async Task<LoginResult> LoginAsync(WebView webView)
    {
       auth0Client.Browser = new WebViewBrowserAuthenticator(webView);
       return await auth0Client.LoginAsync();
    }

    public async Task<BrowserResult> LogoutAsync()
    {
        return await auth0Client.LogoutAsync();
    }
}