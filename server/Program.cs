using Microsoft.AspNetCore.Authentication;
using Server.Business.Contexts;
using Server.Business.Services;
using Server.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<SetupServiceInterface, SetupService>();
builder.Services.AddScoped<TokenServiceInterface, TokenService>();
builder.Services.AddScoped<PasswordServiceInterface, PasswordService>();
builder.Services.AddSingleton<SessionServiceInterface, SessionService>();
builder.Services.AddDbContext<RelationalContext>();
builder.Services.AddSignalR();

builder.Services.AddControllers();

builder.Services
    .AddAuthentication("AuthenticationToken")
        .AddScheme<AuthenticationSchemeOptions, AuthenticationTokenHandler>(
            "AuthenticationToken",
            o => { }
        );

builder.Services
    .AddAuthorization(o => {
        o.AddPolicy("Viewer", p => {
            p.RequireAuthenticatedUser();
            p.RequireRole("Viewer");
        });

        o.AddPolicy("Coordinator", p => {
            p.RequireAuthenticatedUser();
            p.RequireRole("Coordinator");
        });

        o.AddPolicy("Administrator", p => {
            p.RequireAuthenticatedUser();
            p.RequireRole("Administrator");
        });
    });

var app = builder.Build();

app.UseDefaultFiles();
app.UseRouting();
app.MapStaticAssets();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("/index.html");
app.MapHub<SessionService>("live");
app.Run();
