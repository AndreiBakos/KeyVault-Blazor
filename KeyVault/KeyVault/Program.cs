using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using KeyVault.Data;
using KeyVault.DbContext;
using KeyVault.Services.Groups;
using KeyVault.Services.Keys;
using KeyVault.Services.Secrets;
using KeyVault.Services.Users;
using Slapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<KeyVaultContext>(_ => new KeyVaultContext(builder.Configuration));
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ISecretsService, SecretsService>();
builder.Services.AddScoped<IKeysService, KeysService>();
builder.Services.AddScoped<IGroupsService, GroupsService>();
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();