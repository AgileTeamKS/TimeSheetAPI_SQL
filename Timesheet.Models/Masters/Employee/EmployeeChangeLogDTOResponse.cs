using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.Employee
{
    public class EmployeeChangeLogDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public List<EmployeeChangeLogDTOList>? EmployeeChangeLogList { get; set; }

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
            status += $"Employee Change Log List Count:{this.EmployeeChangeLogList?.Count}";
            return status;
        }
    }
    public class EmployeeChangeLogDTOList
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
        public string? IsDeleted { get; set; }
        public string? ValidFrom { get; set; }
        public string? ValidTo { get; set; }
        public string? RecordMode { get; set; }
    }

}
