using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
            string userName = "Admin";
            logger.LogInformation($"Request:User:{userName}");
            var result = employeeCalendar.List(userName);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(EmployeeCalendarDTOAdd employeeCalendarDTOAdd)
        {
            string userName = "Admin";
            string ipAddress = "::1";

            var calendarDate = employeeCalendarDTOAdd.CalendarDate.ToUniversalTime();
            var startTime = employeeCalendarDTOAdd.StartTime.ToUniversalTime();
            var endTime = employeeCalendarDTOAdd.EndTime.ToUniversalTime();

            employeeCalendarDTOAdd.CalendarDate = calendarDate;
            employeeCalendarDTOAdd.StartTime = startTime;
            employeeCalendarDTOAdd.EndTime = endTime;

            EmployeeCalendarDTOAddDB employeeCalendarDTOAddDB = mapper.Map<EmployeeCalendarDTOAddDB>(employeeCalendarDTOAdd);
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
            string userName = "Admin";
            string ipAddress = "::1";

            var calendarDate = employeeCalendarDTOEdit.CalendarDate.ToUniversalTime();
            var startTime = employeeCalendarDTOEdit.StartTime.ToUniversalTime();
            var endTime = employeeCalendarDTOEdit.EndTime.ToUniversalTime();

            employeeCalendarDTOEdit.CalendarDate = calendarDate;
            employeeCalendarDTOEdit.StartTime = startTime;
            employeeCalendarDTOEdit.EndTime = endTime;

            EmployeeCalendarDTOEditDB employeeCalendarDTOEditDB = mapper.Map<EmployeeCalendarDTOEditDB>(employeeCalendarDTOEdit);
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
            string userName = "Admin";
            string ipAddress = "::1";

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
            string userName = "Admin";
            logger.LogInformation($"|Request: User: {userName}");
            var result = employeeCalendar.DeletedList(userName);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int employeeCalendarId)
        {
            string userName = "Admin";
            string ipAddress = "::1";

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
            string userName = "Admin";
            string ipAddress = "::1";

            logger.LogInformation($"Request User: {userName}, IP: {ipAddress}, Employee Calendar Id: {employeeCalendarId}");
            var result = employeeCalendar.ChangeLog_GetById(employeeCalendarId, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }


    }
}
