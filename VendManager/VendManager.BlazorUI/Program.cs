using Blazored.LocalStorage;
using Blazored.Toast;
using DevExpress.XtraCharts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using System.Reflection;
using VendManager.BlazorUI.Contracts;
using VendManager.BlazorUI.Data;
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
builder.Services.AddBlazoredToast();


// Register the token service
builder.Services.AddSingleton<ITokenService, TokenService>();

builder.Services.AddDataProtection()
     // Persist keys to a shared folder accessible by all servers
     .PersistKeysToFileSystem(new DirectoryInfo(@"C:\Users\Public\Keys"))
     // Set a unique application name to ensure key isolation from other apps
     .SetApplicationName("MyBlazorApp");

builder.Services.AddScoped<TokenPersistenceService>();

// Blazor server-side authentication
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Identity/Account/Login";
    });

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});
// Bind ApiSettings from appsettings.json
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserService, UserService>();

//builder.Services.AddHttpClient();
//builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7121/"));

// Register HttpClient with BaseAddress from ApiSettings
builder.Services.AddHttpClient<IClient, Client>((serviceProvider, client) =>
{
    var apiSettings = serviceProvider.GetRequiredService<IOptions<ApiSettings>>().Value;
    client.BaseAddress = new Uri(apiSettings.BaseUrl);
});
builder.Services.AddScoped<IMachineService, MachineService>();
builder.Services.AddScoped<IUserManagementService, UserManagementService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Host.SerilogConfiguration();

var app = builder.Build();


// Read the "ShowDetailedErrors" setting from appsettings.json
var showDetailedErrors = builder.Configuration.GetValue<bool>("ShowDetailedErrors");

// Configure the HTTP request pipeline.
if (showDetailedErrors)
{
    app.UseDeveloperExceptionPage();
}
else
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