using Microsoft.AspNetCore.Identity;

namespace Timesheet.Models.Auth
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
