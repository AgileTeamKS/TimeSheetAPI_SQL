using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Timesheet.Models.Masters.Project;
using Timesheet.Repository.Interface.Master;

namespace Timesheet.API.Controllers.Master
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController(IProject project, ILogger<ProjectController> logger, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string userName = "Admin";
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized(); // Or handle as needed
            }

            logger.LogInformation($"Request User: {userName}");
            var result = project.List(userName);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList()
        {
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized(); // Or handle as needed
            }

            logger.LogInformation($"Request User: {userName}");
            var result = project.DeletedList(userName);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(ProjectDTOAdd projectDTOAdd)
        {
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            ProjectDTOAddDB projectDTOAddDB = mapper.Map<ProjectDTOAddDB>(projectDTOAdd);
            projectDTOAddDB.CreatedBy = userName;
            projectDTOAddDB.CreatedByIpAddress = ipAddress;

            logger.LogInformation($"Request Argument: {projectDTOAddDB}");
            var result = project.Add(projectDTOAddDB);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(ProjectDTOEdit projectDTOEdit)
        {
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            ProjectDTOEditDB projectDTOEditDB = mapper.Map<ProjectDTOEditDB>(projectDTOEdit);
            projectDTOEditDB.ModifiedByIpAddress = ipAddress;
            projectDTOEditDB.ModifiedBy = userName;

            logger.LogInformation($"Request Argument: {projectDTOEditDB}");
            var result = project.Edit(projectDTOEditDB);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int projectId)
        {
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            logger.LogInformation($"Request User: {userName}, IP: {ipAddress}, Project Id: {projectId}");
            var result = project.Delete(projectId, userName, ipAddress);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int projectId)
        {
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            logger.LogInformation($"Request User: {userName}, IP: {ipAddress}, Project Id: {projectId}");
            var result = project.Detail(projectId, userName);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int projectId)
        {
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            logger.LogInformation($"Request User: {userName}, IP: {ipAddress}, Project Id: {projectId}");
            var result = project.ChangeLog_GetById(projectId, userName);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

    }
}
