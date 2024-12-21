using Server.Business.Services;
using Server.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PasswordServiceInterface, PasswordService>();
builder.Services.AddSingleton<TokenServiceInterface, TokenService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("/index.html");
app.Run();
