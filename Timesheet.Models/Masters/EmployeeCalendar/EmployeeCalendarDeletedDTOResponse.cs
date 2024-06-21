using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.EmployeeCalendar
{
    public class EmployeeCalendarDeletedDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public List<EmployeeCalendarDeletedDTOList>? EmployeeCalendarDeletedList { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No Status Available";
            }
            string status = DataUpdateResponse.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Employee Calendar Deleted List Count {this.EmployeeCalendarDeletedList?.Count}";
            return status;
        }
    }

    public class EmployeeCalendarDeletedDTOList
    {
        public int EmployeeCalendarId { get; set; }
        public int CalendarId { get; set; }
        public string Date { get; set; }
        public int ProjectId { get; set; }
        public string Project { get; set; }
        public int WorkTypeId { get; set; }
        public string WorkType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalTime { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
