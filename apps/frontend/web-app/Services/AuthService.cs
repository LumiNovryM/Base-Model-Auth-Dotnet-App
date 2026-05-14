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

    // Login Method
    public async Task<(bool Success, string Message)> LoginAsync(LoginRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(
            ApiEndpoints.Login,
            request);

        var rawResponse = await response.Content.ReadAsStringAsync();

        Console.WriteLine(rawResponse);

        var result =
            System.Text.Json.JsonSerializer.Deserialize<BaseResponse<LoginResponse>>(
                rawResponse,
                new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        if (!response.IsSuccessStatusCode)
        {
            return (false, result?.Message ?? "Login failed");
        }

        if (result is null || !result.Success)
        {
            return (false, result?.Message ?? "Login failed");
        }

        await _tokenService.SetTokenAsync(result.Data!.Token);

        return (true, result.Message);
    }

    // Login Method
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

    // Register Method
    public async Task<(bool Success, string Message)> RegisterAsync(RegisterRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(
            ApiEndpoints.Register,
            request);

        var rawResponse = await response.Content.ReadAsStringAsync();

        Console.WriteLine(rawResponse);

        var result =
            System.Text.Json.JsonSerializer.Deserialize<
                BaseResponse<object>>(
                    rawResponse,
                    new System.Text.Json.JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

        if (!response.IsSuccessStatusCode)
        {
            return (false, result?.Message ?? "Register failed");
        }

        if (result is null || !result.Success)
        {
            return (false, result?.Message ?? "Register failed");
        }

        return (true, result.Message);
    }
}