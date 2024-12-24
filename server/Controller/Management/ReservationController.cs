using Microsoft.AspNetCore.Mvc;

namespace Server.Controller.Management;

[ApiController]
[Route("api/management/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ReservationController : ControllerBase
{

}