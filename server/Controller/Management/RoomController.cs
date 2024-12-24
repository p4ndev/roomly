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
    public async Task<ActionResult<int?>> CreateAsync([FromBody] RoomDto model, CancellationToken token = default)
    {
        RoomEntity? entity = await _roomService.CreateAsync(model, token);

        if (entity is null)
            return BadRequest(null!);

        await _liveService.RoomAddedAsync(entity);

        return Created(string.Empty, entity.Id);
    }
}