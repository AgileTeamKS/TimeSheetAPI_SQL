using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.Employee
{
    public class EmployeeDetailDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public EmployeeDTODetail? EmployeeDetail { get; set; }
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
            status += $"Employee Detail :{this.EmployeeDetail}";
            return status;
        }
    }
    public class EmployeeDTODetail
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
        public string? CreatedBy { get; set; }
        public string? CreatedByIpAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public string? DeletedByIpAddress { get; set; }
        public DateTime? DeletedOn { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
