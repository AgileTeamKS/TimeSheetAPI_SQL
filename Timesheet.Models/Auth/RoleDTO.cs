using System.ComponentModel.DataAnnotations;

namespace Timesheet.Models.Auth
{
    public class RoleDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
