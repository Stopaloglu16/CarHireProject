using WebSite.Services;
using WebSite.Data;
using Domain.Common;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using CarHireRazorClassLibrary.Services;
using WebSite.Handlers;
using WebSite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped<IToastService, ToastService>();


ConfigurationManager configuration = builder.Configuration; //allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

var appSettingSection = configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingSection);

builder.Services.AddTransient<ValidateHeaderHandler>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


builder.Services.AddBlazoredLocalStorage();

builder.Services.AddHttpClient<IUserService, UserService>();

builder.Services.AddHttpClient<IMenuService, MenuService>().AddHttpMessageHandler<ValidateHeaderHandler>();

builder.Services.AddBlazorServices();

builder.Services.AddSingleton<HttpClient>();


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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});

app.Run();
