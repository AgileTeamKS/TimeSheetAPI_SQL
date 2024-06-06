using Newtonsoft.Json;

namespace Timesheet.Models.Masters.EmployeeCalendar
{
    public class EmployeeCalendarDTOEditDB
    {
        public int EmployeeCalendarId { get; set; }
        public int CalendarId { get; set; }
        public int ProjectId { get; set; }
        public int WorkTypeId { get; set; }
        public decimal StartTime { get; set; }
        public decimal EndTime { get; set; }
        public int TotalTime { get; set; }
        public string? Description { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
