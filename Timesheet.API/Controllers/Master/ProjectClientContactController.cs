using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Claims;
using Timesheet.Models.Masters.ProjectClientContact;
using Timesheet.Repository.Interface.Master;

namespace Timesheet.API.Controllers.Master
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectClientContactController(IProjectClientContact projectClientContact, ILogger<ProjectController> logger, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List(int projectId)
        {
            string userName = "Admin";
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized(); // Or handle as needed
            }

            logger.LogInformation($"Request User: {userName}, Project Id: {projectId}");
            var result = projectClientContact.List(projectId, userName);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList(int projectId)
        {
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";
            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized(); // Or handle as needed
            }

            logger.LogInformation($"Request User: {userName}, Project Id: {projectId}");
            var result = projectClientContact.DeletedList(projectId, userName);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(ProjectClientContactDTOAdd projectClientContactDTOAdd)
        {
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            ProjectClientContactDTOAddDB projectClientContactDTOAddDB = mapper.Map<ProjectClientContactDTOAddDB>(projectClientContactDTOAdd);
            projectClientContactDTOAddDB.CreatedBy = userName;
            projectClientContactDTOAddDB.CreatedByIpAddress = ipAddress;

            logger.LogInformation($"Request Argument: {projectClientContactDTOAddDB}");
            var result = projectClientContact.Add(projectClientContactDTOAddDB);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(ProjectClientContactDTOEdit projectClientContactDTOEdit)
        {
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            ProjectClientContactDTOEditDB projectClientContactDTOEditDB = mapper.Map<ProjectClientContactDTOEditDB>(projectClientContactDTOEdit);
            projectClientContactDTOEditDB.ModifiedByIpAddress = ipAddress;
            projectClientContactDTOEditDB.ModifiedBy = userName;

            logger.LogInformation($"Request Argument: {projectClientContactDTOEditDB}");
            var result = projectClientContact.Edit(projectClientContactDTOEditDB);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int projectClientContactId)
        {
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            logger.LogInformation($"Request User: {userName}, IP: {ipAddress}, Project Client Contact Id: {projectClientContactId}");
            var result = projectClientContact.Delete(projectClientContactId, userName, ipAddress);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{projectClientContactId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int projectClientContactId)
        {
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            logger.LogInformation($"Request User: {userName}, IP: {ipAddress}, Project Client Contact Id: {projectClientContactId}");
            var result = projectClientContact.Detail(projectClientContactId, userName);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{projectClientContactId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int projectClientContactId)
        {
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            logger.LogInformation($"Request User: {userName}, IP: {ipAddress}, Project Client Contact Id: {projectClientContactId}");
            var result = projectClientContact.ChangeLog_GetById(projectClientContactId, userName);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }
    }

}