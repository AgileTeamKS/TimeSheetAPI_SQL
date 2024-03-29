using Newtonsoft.Json;

namespace Timesheet.Models.Masters.Employee
{
    public class EmployeeDTOAdd
    {
        public string? EmployeeName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? ContactNumber1 { get; set; }
        public string? ContactNumber2 { get; set; }
        public string? Email1 { get; set; }
        public string? Email2 { get; set; }
        public DateTime JoinedOn { get; set; }
        public int DesignationId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
