using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.EmployeeCalendar
{
    public class EmployeeCalendarDetailDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public EmployeeCalendarDTODetail? EmployeeCalendarDetail { get; set; }
        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No Status Available";
            }
            string status = DataUpdateResponse.ToString();
            if (this.DataUpdateResponse!.Status == false)
            {
                return status;
            }
            status += $"Employee Calendar Details : {this.EmployeeCalendarDetail}";
            return status;
        }
    }

    public class EmployeeCalendarDTODetail
    {
        public int EmployeeCalendarId { get; set; }
        public int CalendarId { get; set; }
        public int ProjectId { get; set; }
        public int WorkTypeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalTime { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedByIpAddress {  get; set; }
		public DateTime CreatedOn { get; set; }
		public string? ModifiedBy { get; set; }
		public string? ModifiedByIpAddress { get; set; }
	    public DateTime ModifiedOn { get; set; }
		public bool IsDeleted { get; set; }
		public string? DeletedBy { get; set; }
		public string? DeletedByIpAddress { get; set; }
		public DateTime DeletedOn { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
