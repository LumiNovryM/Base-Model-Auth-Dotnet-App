using web_app.Components;
using Blazored.LocalStorage;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Components.Authorization;
using web_app.Services;
using web_app.Providers;
using web_app.Models.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<TokenService>();

builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<
    AuthenticationStateProvider,
    CustomAuthenticationStateProvider>();

builder.Services.Configure<ApiSettings>(
    builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddScoped(sp =>
{
    var apiSettings = sp
        .GetRequiredService<IOptions<ApiSettings>>()
        .Value;

    return new HttpClient
    {
        BaseAddress = new Uri(apiSettings.BaseUrl)
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
