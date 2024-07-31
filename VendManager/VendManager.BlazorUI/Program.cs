using Blazored.LocalStorage;
using DevExpress.XtraCharts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Reflection;
using VendManager.BlazorUI.Contracts;
using VendManager.BlazorUI.Data;
using VendManager.BlazorUI.Providers;
using VendManager.BlazorUI.Services;
using VendManager.BlazorUI.Services.Base;
using VendManager.BlazorUI.Services.HttpContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDevExpressBlazor(options => {
    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
    options.SizeMode = DevExpress.Blazor.SizeMode.Medium;
});
builder.Services.AddSingleton<WeatherForecastService>();
builder.WebHost.UseWebRoot("wwwroot");
builder.WebHost.UseStaticWebAssets();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

// Register CustomAuthenticationStateProvider
//builder.Services.AddScoped<CustomAuthenticationStateProvider>();
//builder.Services.AddSingleton<CustomAuthenticationService>();

// Add custom authentication state provider
//builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


// Add protected session storage
//builder.Services.AddScoped<ProtectedSessionStorage>();

//builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
//builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

// Register the token service
builder.Services.AddSingleton<ITokenService, TokenService>();

// Register the HTTP client and use the custom handler
//builder.Services.AddHttpClient("ApiClient")
  //  .AddHttpMessageHandler<AuthHttpClientHandler>();

builder.Services.AddScoped<TokenPersistenceService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Identity/Account/Login";
    });

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserService, UserService>();

//builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7121/"));
builder.Services.AddScoped<IMachineService, MachineService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// Add authentication and authorization middlewares
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();