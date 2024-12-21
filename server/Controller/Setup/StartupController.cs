using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Business.Services;
using Server.Data.Interfaces;

namespace Server.Controller.Setup;

[ApiController]
[Route("api/setup/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class StartupController(SetupServiceInterface _setupServices, SessionService _sessionService) : ControllerBase
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
        byte[]? output;

        if (_sessionService.Logotype is null)
        {
            output = await _setupServices.LogotypeAsync(token);
            _sessionService.Logotype = output;
        }            
        else
            output = _sessionService.Logotype;

        if (output is null)
            return NotFound(null);

        return File(output, "image/png");
    }
}