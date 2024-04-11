using static Timesheet.Models.Auth.AuthResponse;
using Timesheet.Models.Auth;
using Timesheet.Repository.Interface.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Timesheet.Repository.Repository.Auth
{
    public class AccountRepository(UserManager<AppUser> _userManager, RoleManager<IdentityRole> _roleManager, IConfiguration _configuration) : IUserAccount
    {
        private readonly UserManager<AppUser> userManager = _userManager;
        private readonly RoleManager<IdentityRole> roleManager = _roleManager;
        private readonly IConfiguration configuration = _configuration;

        public async Task<GeneralResponse> CreateAccount(UserDTO userDTO)
        {
            if (userDTO == null) return new GeneralResponse(false, "Model is empty");
            var newUser = new AppUser()
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                PasswordHash = userDTO.Password,
                UserName = userDTO.Email
            };
            var user = await userManager.FindByEmailAsync(newUser.Email);
            if (user is not null) return new GeneralResponse(false, "User Email is already in use!");

            var createUser = await userManager.CreateAsync(newUser!, userDTO.Password);
            if (!createUser.Succeeded) return new GeneralResponse(false, "Enter Appropriate Password");

            var userRole = await roleManager.FindByNameAsync("Admin");
            if (userRole is null)
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
                await userManager.AddToRoleAsync(newUser, "Admin");
                return new GeneralResponse(true, "Account created successfully");
            }
            else
            {
                var checkUser = await roleManager.FindByNameAsync("User");
                if (checkUser is null)
                { 
                    await roleManager.CreateAsync(new IdentityRole() { Name = "User" }); 
                }
                await userManager.AddToRoleAsync(newUser, "User");
                return new GeneralResponse(true, "Account created successfully");
            }
        }

        public async Task<LoginResponse> LoginAccount(LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return new LoginResponse(false, null!, "Enter UserName and Password!");
            }

            var getUser = await userManager.FindByEmailAsync(loginDTO.Email);
            if (getUser is null)
            {
                return new LoginResponse(false, null!, "User not found!");
            }

            bool checkUserPassword = await userManager.CheckPasswordAsync(getUser, loginDTO.Password);
            if (!checkUserPassword)
            {
                return new LoginResponse(false, null!, "The Password and Username do not match, please try again!");
            }

            var getUserRole = await userManager.GetRolesAsync(getUser);
            var userSession = new UserSession(getUser.Id, getUser.Name, getUser.Email, getUserRole.First());
            string token = GenerateToken(userSession);
            return new LoginResponse(true, token!, "Logged in successfully");
        }

        private string GenerateToken(UserSession user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userClaims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
        };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
