using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Interfaces;
using Server.Data.Dtos;

namespace Server.Controller.Setup;

[ApiController]
[Route("api/setup/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class AccessController(SetupServiceInterface _setupService) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AccessDto>> PasswordAsync(CancellationToken token = default)
    {
        var output = await _setupService.LoadAsync(token);

        if(output is null)
            return NotFound(null);

        await _setupService.ExposeAsync(token);

        return Ok(output);
    }
}