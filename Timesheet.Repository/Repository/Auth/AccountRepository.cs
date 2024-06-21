using static Timesheet.Models.Auth.AuthResponse;
using Timesheet.Models.Auth;
using Timesheet.Repository.Interface.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Timesheet.Models.Common;
using System.Data.SqlClient;
using System.Data;
using Timesheet.DAL;
using Timesheet.Models.Masters.Employee;
using Dapper;

namespace Timesheet.Repository.Repository.Auth
{
    public class AccountRepository(UserManager<AppUser> _userManager, RoleManager<IdentityRole> _roleManager, IConfiguration _configuration, AppConnectionString _appConnectionString) : IUserAccount
    {
        private readonly UserManager<AppUser> userManager = _userManager;
        private readonly RoleManager<IdentityRole> roleManager = _roleManager;
        private readonly IConfiguration configuration = _configuration;
        private readonly AppConnectionString appConnectionString = _appConnectionString;

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
            return new GeneralResponse(true, "Account created successfully");
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
            new Claim("nameid", user.Id),
            new Claim("name", user.Name),
            new Claim("email", user.Email),
            new Claim("role", user.Role),
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

        public async Task<GeneralResponse> CreateRole(RoleDTO roleDTO)
        {
            if (roleDTO == null) return new GeneralResponse(false, "Role name cannot be empty");

            var newRole = new RoleDTO()
            {
                Name = roleDTO.Name,
            };
            var role = await roleManager.FindByNameAsync(newRole.Name);
            if (role is not null) return new GeneralResponse(false, "This Role already exists!");

            await roleManager.CreateAsync(new IdentityRole() { Name = newRole.Name });
            return new GeneralResponse(true, "Role created succesfully");
        }

        public RoleDTOResponse List(string userName)
        {
            RoleDTOResponse response = new RoleDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Role_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status)
                {
                    if (!result.IsConsumed)
                    {
                        response.RoleList = result.Read<RoleResponse>().ToList();
                    }
                }
            }
            return response;
        }

        public RoleDTOResponseList RoleList(string userName)
        {
            RoleDTOResponseList response = new RoleDTOResponseList();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Role_List_Admin_Count", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status)
                {
                    if (!result.IsConsumed)
                    {
                        response.RoleResponseList = result.Read<RoleResponseList>().ToList();
                    }
                }
            }
            return response;
        }
    }
}
