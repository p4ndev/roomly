using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Interfaces;
using Server.Data.Dtos;

namespace Server.Controller.Setup;

[ApiController]
[AllowAnonymous]
[Route("api/setup/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status409Conflict)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class InstallationController(SetupServiceInterface _setupServices, PasswordServiceInterface _passwordService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> InstallationAsync([Required][FromBody] InstallationDto? installationRequest, CancellationToken token = default)
    {
        object? placeholder = null;

        if (await _setupServices.ExistAsync(token))
            return Conflict(placeholder);

        if (!_setupServices.IsValid(installationRequest))
            return new UnsupportedMediaTypeResult();

        var accessRequest = new AccessDto(
            _passwordService.Generate(),
            _passwordService.Generate(),
            _passwordService.Generate()
        );

        if (await _setupServices.InstallAsync(installationRequest!, accessRequest, token))
            return Created();
        
        return BadRequest(placeholder);
    }
}