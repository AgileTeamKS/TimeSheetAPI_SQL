using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Timesheet.Models.Masters.Client;
using Timesheet.Repository.Interface.Master;

namespace Timesheet.API.Controllers.Master
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    // [Authorize]
    public class ClientController(IClient client, ILogger<ClientController> logger, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            //hello this is temp changes.
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized(); // Or handle as needed
            }

            logger.LogInformation($"Request User: {userName}");
            var result = client.List(userName);
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
            var result = client.DeletedList(userName);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(ClientDTOAdd clientDTOAdd)
        {
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            ClientDTOAddDB clientDTOAddDB = mapper.Map<ClientDTOAddDB>(clientDTOAdd);
            clientDTOAddDB.CreatedBy = userName;
            clientDTOAddDB.CreatedByIpAddress = ipAddress;

            logger.LogInformation($"Request Argument: {clientDTOAddDB}");
            var result = client.Add(clientDTOAddDB);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(ClientDTOEdit clientDTOEdit)
        {
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            ClientDTOEditDB clientDTOEditDB = mapper.Map<ClientDTOEditDB>(clientDTOEdit);
            clientDTOEditDB.ModifiedByIpAddress = ipAddress;
            clientDTOEditDB.ModifiedBy = userName;

            logger.LogInformation($"Request Argument: {clientDTOEditDB}");
            var result = client.Edit(clientDTOEditDB);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int clientId)
        {
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";

            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            logger.LogInformation($"Request User: {userName}, IP: {ipAddress}, Client Id: {clientId}");
            var result = client.Delete(clientId, userName, ipAddress);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int clientId)
        {
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            logger.LogInformation($"Request User: {userName}, IP: {ipAddress}, Client Id: {clientId}");
            var result = client.Detail(clientId, userName);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int clientId)
        {
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string userName = "Admin";
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            logger.LogInformation($"Request User: {userName}, IP: {ipAddress}, Client Id: {clientId}");
            var result = client.ChangeLog_GetById(clientId, userName);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

    }
}
