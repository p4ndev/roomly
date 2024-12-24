using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Interfaces;
using Server.Data.Entities;

namespace Server.Controller.Management;

[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class DashboardController(RoomServiceInterface _roomService) : ControllerBase
{
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IList<RoomEntity>>> LoadAsync(CancellationToken token = default)
    {
        IList<RoomEntity> entities = await _roomService.ListAsync(token);

        if (entities.Count <= 0)
            return NotFound(null);

        return Ok(entities);
    }
}