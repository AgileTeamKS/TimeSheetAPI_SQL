using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Timesheet.Repository.Interface.Master;

namespace Timesheet.API.Controllers.Master
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalendarController(ICalendar calendar, ILogger<CalendarController> logger, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            logger.LogInformation($"Request:User:{userName}");
            var result = calendar.List(userName);
            return Ok(result);
        }
    }
}
