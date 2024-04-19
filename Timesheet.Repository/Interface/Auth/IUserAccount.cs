using Timesheet.Models.Auth;
using Timesheet.Models.Common;
using Timesheet.Models.Masters.Employee;
using static Timesheet.Models.Auth.AuthResponse;

namespace Timesheet.Repository.Interface.Auth
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAccount (UserDTO userDTO);

        Task<LoginResponse> LoginAccount (LoginDTO loginDTO);

        Task<GeneralResponse> CreateRole (RoleDTO roleDTO);
        /*Task<GeneralResponse> RoleList (RoleDTODB roleDTODB);*/

        RoleDTOResponse List(string userName);

    }
}
