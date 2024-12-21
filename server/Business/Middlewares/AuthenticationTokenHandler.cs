using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using Server.Data.Interfaces;
using System.Security.Claims;

public class AuthenticationTokenHandler(
    TokenServiceInterface                           _tokenService,
    IOptionsMonitor<AuthenticationSchemeOptions>    _options,
    ILoggerFactory                                  _logger,
    UrlEncoder                                      _encoder
) : AuthenticationHandler<AuthenticationSchemeOptions>(
    _options,
    _logger,
    _encoder
)
{
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        try
        {
            var header = Request.Headers["Authorization"].FirstOrDefault();

            if (header is null)
                return Task.FromResult(AuthenticateResult.Success(null!));

            var token = header!.Split(" ").Last();

            if(string.IsNullOrEmpty(token))
                return Task.FromResult(AuthenticateResult.Fail("No token provided"));

            var role = _tokenService.Decrypt(token);

            var claims = new[] {
                new Claim(ClaimTypes.Role, role)
            };

            var identity    = new ClaimsIdentity(claims, Scheme.Name);
            var principal   = new ClaimsPrincipal(identity);
            var ticket      = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
        catch (Exception)
        {
            return Task.FromResult(AuthenticateResult.Fail("Invalid or expired token"));
        }
    }
}
