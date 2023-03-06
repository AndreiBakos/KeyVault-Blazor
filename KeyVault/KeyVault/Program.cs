using System.Text;
using KeyVault.DbContext;
using KeyVault.Services.Groups;
using KeyVault.Services.Keys;
using KeyVault.Services.Secrets;
using KeyVault.Services.Users;
using KeyVault.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<KeyVaultContext>(_ => new KeyVaultContext(builder.Configuration));
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ISecretsService, SecretsService>();
builder.Services.AddScoped<IKeysService, KeysService>();
builder.Services.AddScoped<IGroupsService, GroupsService>();
builder.Services.AddScoped<CryptoTool>();
builder.Services.AddScoped<TokenTools>();
builder.Services.AddScoped<LocalStorage>();
builder.Services.AddHttpClient();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });
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