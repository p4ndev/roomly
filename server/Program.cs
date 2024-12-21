using Microsoft.AspNetCore.Authentication;
using Server.Business.Contexts;
using Server.Business.Services;
using Server.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PasswordServiceInterface, PasswordService>();
builder.Services.AddSingleton<TokenServiceInterface, TokenService>();
builder.Services.AddTransient<SetupServiceInterface, SetupService>();
builder.Services.AddDbContext<RelationalContext>();

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
app.MapStaticAssets();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("/index.html");
app.Run();
