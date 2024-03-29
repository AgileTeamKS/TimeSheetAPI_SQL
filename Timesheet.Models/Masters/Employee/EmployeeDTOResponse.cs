using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.Employee
{
    public class EmployeeDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public List<EmployeeDTOList>? EmployeeList { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Employee List Count:{this.EmployeeList?.Count}";
            return status;
        }
    }
    public class EmployeeDTOList
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? ContactNumber1 { get; set; }
        public string? ContactNumber2 { get; set; }
        public string? Email1 { get; set; }
        public string? Email2 { get; set; }
        public DateTime JoinedOn { get; set; }
        public int DesignationId { get; set; }
        public string? Designation { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
