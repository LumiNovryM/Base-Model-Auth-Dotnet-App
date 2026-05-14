using System.Net.Http.Headers;
using System.Net.Http.Json;
using web_app.Constants;
using web_app.Models.Requests;
using web_app.Models.Responses;

namespace web_app.Services;

public class AuthService
{
    private readonly HttpClient _httpClient;

    private readonly TokenService _tokenService;

    public AuthService(
        HttpClient httpClient,
        TokenService tokenService)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
    }

    public async Task<bool> LoginAsync(LoginRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(
            ApiEndpoints.Login,
            request);

        if (!response.IsSuccessStatusCode)
            return false;

        var result =
            await response.Content.ReadFromJsonAsync<
                BaseResponse<LoginResponse>>();

        if (result is null || !result.Success)
            return false;

        await _tokenService.SetTokenAsync(result.Data!.Token);

        return true;
    }

    public async Task<bool> ValidateTokenAsync()
    {
        var token = await _tokenService.GetTokenAsync();

        if (string.IsNullOrWhiteSpace(token))
            return false;

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.GetAsync(ApiEndpoints.Profile);

        return response.IsSuccessStatusCode;
    }

    public async Task LogoutAsync()
    {
        await _tokenService.RemoveTokenAsync();
    }
}