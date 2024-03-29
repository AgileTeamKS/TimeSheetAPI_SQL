using Newtonsoft.Json;

namespace Timesheet.Models.Masters.Employee
{
    public class EmployeeDTOAddDB
    {
        public string? EmployeeName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? ContactNumber1 { get; set; }
        public string? ContactNumber2 { get; set; }
        public string? Email1 { get; set; }
        public string? Email2 { get; set; }
        public DateTime JoinedOn { get; set; }
        public int DesignationId { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
