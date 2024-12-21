using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Interfaces;
using Server.Data.Enums;
using Server.Data.Dtos;

namespace Server.Controller.Setup;

[ApiController]
[AllowAnonymous]
[Route("api/setup/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class AuthenticationController(SetupServiceInterface _setupServices, TokenServiceInterface _tokenService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AuthenticationDto>> ConnectAsync([FromHeader] string password, CancellationToken token = default)
    {
        RoleEnum? role = await _setupServices.FindAsync(password, token);

        if(!role.HasValue)
            return NotFound(null);

        var output = new AuthenticationDto(
            _tokenService.Generate(role.Value),
            role.Value.ToString()
        );

        return Ok(output);
    }
}