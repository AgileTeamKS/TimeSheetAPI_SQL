namespace Timesheet.Models.Auth
{
    public class AuthResponse
    {
        public record class GeneralResponse(bool flag, string message);

        public record class LoginResponse(bool flag, string token, string message);
    
    }
}
