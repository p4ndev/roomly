using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Interfaces;

namespace Server.Controller.Setup;

[ApiController]
[Route("api/setup/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class StartupController(SetupServiceInterface _setupServices) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> StartupAsync(CancellationToken token = default)
    {
        if (await _setupServices.ExistAsync(token))
            return Ok();

        return NotFound(null);
    }

    [HttpGet("logotype")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult?> BrandAsync(CancellationToken token = default)
    {
        var output = await _setupServices.LogotypeAsync(token);

        if (output is null)
            return NotFound(null);

        return File(output, "image/png");
    }
}