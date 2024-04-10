using Timesheet.Models.Auth;
using static Timesheet.Models.Auth.AuthResponse;

namespace Timesheet.Repository.Interface.Auth
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAccount (UserDTO userDTO);

        Task<LoginResponse> LoginAccount (LoginDTO loginDTO);

    }
}
