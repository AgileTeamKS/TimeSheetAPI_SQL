using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Timesheet.Models.Masters.ClientContact;
using Timesheet.Repository.Interface.Master;

namespace Timesheet.API.Controllers.Master
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    // [Authorize]
    public class ClientContactController(IClientContact clientContact, ILogger<ClientContactController> logger, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List(int clientId)
        {
            string userName = "Admin";
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized(); // Or handle as needed
            }

            logger.LogInformation($"Request User: {userName}, Client Id: {clientId}");
            var result = clientContact.List(clientId, userName);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList(int clientId)
        {
            string userName = "Admin";
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized(); // Or handle as needed
            }

            logger.LogInformation($"Request User: {userName}, Client Id: {clientId}");
            var result = clientContact.DeletedList(clientId, userName);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(ClientContactDTOAdd clientContactDTOAdd)
        {
            string userName = "Admin";
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            ClientContactDTOAddDB clientContactDTOAddDB = mapper.Map<ClientContactDTOAddDB>(clientContactDTOAdd);
            clientContactDTOAddDB.CreatedBy = userName;
            clientContactDTOAddDB.CreatedByIpAddress = ipAddress;

            logger.LogInformation($"Request Argument: {clientContactDTOAddDB}");
            var result = clientContact.Add(clientContactDTOAddDB);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(ClientContactDTOEdit clientContactDTOEdit)
        {
            string userName = "Admin";
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            ClientContactDTOEditDB clientContactDTOEditDB = mapper.Map<ClientContactDTOEditDB>(clientContactDTOEdit);
            clientContactDTOEditDB.ModifiedByIpAddress = ipAddress;
            clientContactDTOEditDB.ModifiedBy = userName;

            logger.LogInformation($"Request Argument: {clientContactDTOEditDB}");
            var result = clientContact.Edit(clientContactDTOEditDB);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int clientContactId)
        {
            string userName = "Admin";
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            logger.LogInformation($"Request User: {userName}, IP: {ipAddress}, Client Contact Id: {clientContactId}");
            var result = clientContact.Delete(clientContactId, userName, ipAddress);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{clientContactId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int clientContactId)
        {
            string userName = "Admin";
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            logger.LogInformation($"Request User: {userName}, IP: {ipAddress}, Client Contact Id: {clientContactId}");
            var result = clientContact.Detail(clientContactId, userName);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{clientContactId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int clientContactId)
        {
            string userName = "Admin";
            //string? userName = User.FindFirst(ClaimTypes.Email)?.Value;
            string? ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                logger.LogWarning("Username not found in token.");
                return Unauthorized();
            }

            logger.LogInformation($"Request User: {userName}, IP: {ipAddress}, Client Contact Id: {clientContactId}");
            var result = clientContact.ChangeLog_GetById(clientContactId, userName);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }
    }
}
