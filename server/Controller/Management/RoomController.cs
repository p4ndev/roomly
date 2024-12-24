using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Interfaces;
using Server.Data.Entities;
using Server.Data.Dtos;

namespace Server.Controller.Dashboard;

[ApiController]
[Route("api/management/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class RoomController(RoomServiceInterface _roomService) : ControllerBase
{
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status304NotModified)]
    public async Task<IActionResult> CreateAsync([FromBody] RoomDto model, CancellationToken token = default)
    {
        int? entityId = await _roomService.CreateAsync(model, token);

        if (!entityId.HasValue)
            return StatusCode(StatusCodes.Status304NotModified);

        return Created("api/management/room", entityId);
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IList<RoomEntity>>> AllAsync(CancellationToken token = default)
    {
        IList<RoomEntity> entities = await _roomService.ListAsync(token);

        if (entities.Count <= 0)
            return NotFound();

        return Ok(entities);
    }
}