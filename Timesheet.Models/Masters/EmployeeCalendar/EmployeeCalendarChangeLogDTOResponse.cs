using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.EmployeeCalendar
{
    public class EmployeeCalendarChangeLogDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public List<EmployeeCalendarChangeLogDTOList>? EmployeeCalendarChangeLogList {  get; set; }
        public override string ToString()
        {
            if (DataUpdateResponse == null)
            {
                return $"No Status Available";
            }
            string status = DataUpdateResponse.ToString();
            if (DataUpdateResponse!.Status == false)
            {
                return status;
            }
            status += $"Employee Calendar Change Log List Count: {this.EmployeeCalendarChangeLogList?.Count}";
            return status;
        }
    }

    public class EmployeeCalendarChangeLogDTOList
    {
        public int EmployeeCalendarId { get; set; }
        public int CalendarId { get; set; }
        public int ProjectId { get; set; }
        public int WorkTypeId { get; set; }
        public decimal StartTime { get; set; }
        public decimal EndTime { get; set; }
        public int TotalTime { get; set; }
        public string? Description { get; set; }
        public string? IsDeleted { get; set; }
        public string? ValidFrom { get; set; }
        public string? ValidTo { get; set; }
        public string? RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
