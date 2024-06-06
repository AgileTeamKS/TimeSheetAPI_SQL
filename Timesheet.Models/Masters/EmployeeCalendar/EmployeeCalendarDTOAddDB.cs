using Newtonsoft.Json;

namespace Timesheet.Models.Masters.EmployeeCalendar
{
    public class EmployeeCalendarDTOAddDB
    {
        public int CalendarId { get; set; }
        public int ProjectId { get; set; }
        public int WorkTypeId { get; set; }
        public decimal StartTime { get; set; }
        public decimal EndTime { get; set; }
        public int TotalTime { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
