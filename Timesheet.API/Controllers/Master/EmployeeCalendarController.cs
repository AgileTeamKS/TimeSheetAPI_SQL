using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Timesheet.Models.Masters.EmployeeCalendar;
using Timesheet.Repository.Interface.Master;

namespace Timesheet.API.Controllers.Master
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeCalendarController(IEmployeeCalendar employeeCalendar, ILogger<EmployeeCalendarController> logger, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            logger.LogInformation($"Request:User:{userName}");
            var result = employeeCalendar.List(userName);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(EmployeeCalendarDTOAdd employeeCalendarDTOAdd)
        {
            //var emailClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "email")?.Value;

            //string? userName2 = User.Claims.FirstOrDefault(c => c.Type == "email")?.Value;

            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            string? userName = User.FindFirst(ClaimTypes.Email)?.Value;


            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized(); // Or handle as needed
            }

            //var calendarDate = employeeCalendarDTOAdd.StartTime.ToUniversalTime();
            //var startTime = employeeCalendarDTOAdd.StartTime.ToUniversalTime();
            //var endTime = employeeCalendarDTOAdd.EndTime.ToUniversalTime();

            //employeeCalendarDTOAdd.CalendarDate = calendarDate;
            //employeeCalendarDTOAdd.StartTime = startTime;
            //employeeCalendarDTOAdd.EndTime = endTime;

            EmployeeCalendarDTOAddDB employeeCalendarDTOAddDB = mapper.Map<EmployeeCalendarDTOAddDB>(employeeCalendarDTOAdd);
            employeeCalendarDTOAdd.CalendarDate = employeeCalendarDTOAdd.CalendarDate.ToLocalTime();
            employeeCalendarDTOAdd.StartTime = employeeCalendarDTOAdd.StartTime.ToLocalTime();
            employeeCalendarDTOAdd.EndTime = employeeCalendarDTOAdd.EndTime.ToLocalTime();
            employeeCalendarDTOAddDB.CreatedByIpAddress = ipAddress;
            employeeCalendarDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument: {employeeCalendarDTOAddDB}");
            var result = employeeCalendar.Add(employeeCalendarDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(EmployeeCalendarDTOEdit employeeCalendarDTOEdit)
        {
            string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            //var calendarDate = employeeCalendarDTOEdit.CalendarDate.ToUniversalTime();
            //var startTime = employeeCalendarDTOEdit.StartTime.ToUniversalTime();
            //var endTime = employeeCalendarDTOEdit.EndTime.ToUniversalTime();

            //employeeCalendarDTOEdit.CalendarDate = calendarDate;
            //employeeCalendarDTOEdit.StartTime = startTime;
            //employeeCalendarDTOEdit.EndTime = endTime;

            EmployeeCalendarDTOEditDB employeeCalendarDTOEditDB = mapper.Map<EmployeeCalendarDTOEditDB>(employeeCalendarDTOEdit);
            employeeCalendarDTOEdit.CalendarDate = employeeCalendarDTOEdit.CalendarDate.ToLocalTime();
            employeeCalendarDTOEdit.StartTime = employeeCalendarDTOEdit.StartTime.ToLocalTime();
            employeeCalendarDTOEdit.EndTime = employeeCalendarDTOEdit.EndTime.ToLocalTime();
            employeeCalendarDTOEditDB.ModifiedBy = userName;
            employeeCalendarDTOEditDB.ModifiedByIpAddress = ipAddress;
            logger.LogInformation($"|Request Argument: {employeeCalendarDTOEditDB}");
            var result = employeeCalendar.Edit(employeeCalendarDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{employeeCalendarId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int employeeCalendarId)
        {
            string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            logger.LogInformation($"Request: User:{userName}, IP:{ipAddress}, EmployeeCalendarId: {employeeCalendarId}");
            var result = employeeCalendar.Detail(employeeCalendarId, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList()
        {
            string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            logger.LogInformation($"|Request: User: {userName}");
            var result = employeeCalendar.DeletedList(userName);
            return Ok(result);
        }

        [HttpPost]
        [Route("{employeeCalendarId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int employeeCalendarId)
        {
            string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            logger.LogInformation($"|Request User: {userName}, IP:{ipAddress}, Employee Calendar Id:{employeeCalendarId}");
            var result = employeeCalendar.Delete(employeeCalendarId, userName, ipAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{employeeCalendarId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int employeeCalendarId)
        {
            string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            logger.LogInformation($"Request User: {userName}, IP: {ipAddress}, Employee Calendar Id: {employeeCalendarId}");
            var result = employeeCalendar.ChangeLog_GetById(employeeCalendarId, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }


    }
}
