using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Timesheet.Models.Masters.Lookup;
using Timesheet.Repository.Interface.Master;

namespace Timesheet.API.Controllers.Master
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class LookupController(ILookup lookup, ILogger<LookupController> logger, IMapper mapper) : ControllerBase
    {


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string userName = "Admin";
            logger.LogInformation($"Request:User:{userName}");
            var result = lookup.List(userName);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(LookupDTOAdd lookupDTOAdd)
        {
            string userName = "Admin";
            string ipAddress = "::1";

            LookupDTOAddDB lookupDTOAddDB = mapper.Map<LookupDTOAddDB>(lookupDTOAdd);
            lookupDTOAddDB.CreatedByIpAddress = ipAddress;
            lookupDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{lookupDTOAddDB}");
            var result = lookup.Add(lookupDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(LookupDTOEdit lookupDTOEdit)
        {
            string userName = "Admin";
            string ipAddress = "::1";
            LookupDTOEditDB lookupDTOEditDB = mapper.Map<LookupDTOEditDB>(lookupDTOEdit);
            lookupDTOEditDB.ModifiedByIpAddress = ipAddress;
            lookupDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument: {lookupDTOEditDB}");
            var result = lookup.Edit(lookupDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{lookupId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int lookupId)
        {
            string userName = "Admin";
            string ipAddress = "::1";
            logger.LogInformation($"|Request: User:{userName}, IP:{ipAddress}, LookupId: {lookupId}");
            var result = lookup.Detail(lookupId, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList()
        {
            string userName = "Admin";
            logger.LogInformation($"|Request: User:{userName}");
            var result = lookup.DeletedList(userName);
            return Ok(result);
        }

        [HttpGet]
        [Route("{tagName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult LookupGetByTagName(string tagName)
        {
            string userName = "Admin";
            string ipAddress = "::1";

            logger.LogInformation($"|Request: User:{userName}, IP:{ipAddress}, TagName: {tagName}");
            var result = lookup.LookupGetByTagName(tagName, userName);
            logger.LogInformation($"|Result: {result}");

            return Ok(result);
        }
    }
}
