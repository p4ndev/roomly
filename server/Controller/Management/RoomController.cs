using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Interfaces;
using Server.Data.Entities;
using Server.Data.Enums;
using Server.Data.Dtos;

namespace Server.Controller.Management;

[ApiController]
[Route("api/management/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class RoomController(RoomServiceInterface _roomService, LiveServiceInterface _liveService) : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = nameof(RoleEnum.Administrator))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status304NotModified)]
    public async Task<IActionResult> CreateAsync([FromBody] RoomDto model, CancellationToken token = default)
    {
        RoomEntity? entity = await _roomService.CreateAsync(model, token);

        if (entity is null)
            return StatusCode(StatusCodes.Status304NotModified);

        await _liveService.RoomAddedAsync(entity);

        return Created("api/management/room", entity);
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