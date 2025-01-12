﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Timesheet.Models.Masters.Employee;
using Timesheet.Repository.Interface.Master;

namespace Timesheet.API.Controllers.Master
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    /*[Authorize]*/
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee Employee;
        private readonly ILogger<EmployeeController> Logger;
        private readonly IMapper Mapper;

        public EmployeeController(IEmployee employee, ILogger<EmployeeController> logger, IMapper mapper)
        {
            Employee = employee;
            Logger = logger;
            Mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            Logger.LogInformation($"|Request:User:{userName}");
            var result = Employee.List(userName);
            Logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(EmployeeDTOAdd employeeDTOAdd)
        {
            string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            EmployeeDTOAddDB employeeDTOAddDB = Mapper.Map<EmployeeDTOAddDB>(employeeDTOAdd);
            employeeDTOAddDB.CreatedByIpAddress = ipAddress;
            employeeDTOAddDB.CreatedBy = userName;
            Logger.LogInformation($"|Request Argument:{employeeDTOAddDB}");
            var result = Employee.Add(employeeDTOAddDB);
            Logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public IActionResult Edit(EmployeeDTOEdit employeeDTOEdit)
        {
            string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            EmployeeDTOEditDB employeeDTOEditDB = Mapper.Map<EmployeeDTOEditDB>(employeeDTOEdit);
            employeeDTOEditDB.ModifiedByIpAddress = ipAddress;
            employeeDTOEditDB.ModifiedBy = userName;
            Logger.LogInformation($"|Request Argument:{employeeDTOEditDB}");
            var result = Employee.Edit(employeeDTOEditDB);
            Logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public IActionResult Delete(int employeeId)
        {
            string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            Logger.LogInformation($"|Request User:{userName}, IP:{ipAddress}, EmployeeId:{employeeId}");
            var result = Employee.Delete(employeeId, userName, ipAddress);
            Logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public IActionResult Detail(int employeeId)
        {
            string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            Logger.LogInformation($"|Request: User:{userName},IP:{ipAddress}, EmployeeId:{employeeId}");
            var result = Employee.Detail(employeeId, userName);
            Logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public IActionResult ChangeLog_GetById(int employeeId)
        {
            string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            Logger.LogInformation($"|Request: User:{userName}, IP:{ipAddress}, EmployeeId:{employeeId}");
            var result = Employee.ChangeLog_GetById(employeeId, userName);
            Logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }

}
