using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Timesheet.Models.Auth;
using Timesheet.Repository.Interface.Auth;

namespace Timesheet.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IUserAccount userAccount) : ControllerBase
    {
        [HttpPost("register")]
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
    }
}
