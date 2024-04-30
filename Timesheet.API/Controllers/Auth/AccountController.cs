using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Timesheet.API.Controllers.Master;
using Timesheet.Models.Auth;
using Timesheet.Repository.Interface.Auth;
using Timesheet.Repository.Interface.Master;

namespace Timesheet.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IUserAccount userAccount, ILogger<AccountController> logger, IMapper mapper) : ControllerBase
    {



        [HttpPost("register")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            var response = await userAccount.CreateAccount(userDTO);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var response = await userAccount.LoginAccount(loginDTO);
            return Ok(response);
        }

        [HttpPost("role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole(RoleDTO roleDTO)
        {
            var response = await userAccount.CreateRole(roleDTO);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string userName = "Admin";
            var response = userAccount.List(userName);
            return Ok(response);
        }

        [HttpGet("rolelist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult RoleList()
        {
            string userName = "Admin";
            var response = userAccount.RoleList(userName);
            return Ok(response);
        }

    }
}
