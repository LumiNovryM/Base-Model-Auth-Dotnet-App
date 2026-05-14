using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using web_app.Services;

namespace web_app.Providers;

public class CustomAuthenticationStateProvider
    : AuthenticationStateProvider
{
    private readonly AuthService _authService;

    public CustomAuthenticationStateProvider(
        AuthService authService)
    {
        _authService = authService;
    }

    public override async Task<AuthenticationState>
        GetAuthenticationStateAsync()
    {
        var isValid = await _authService.ValidateTokenAsync();

        ClaimsIdentity identity;

        if (isValid)
        {
            identity = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.Name, "AuthenticatedUser")
                },
                "jwtAuth");
        }
        else
        {
            identity = new ClaimsIdentity();
        }

        var user = new ClaimsPrincipal(identity);

        return new AuthenticationState(user);
    }

    public void NotifyAuthenticationStateChanged()
    {
        NotifyAuthenticationStateChanged(
            GetAuthenticationStateAsync());
    }
}