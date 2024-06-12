using Newtonsoft.Json;

namespace Timesheet.Models.Masters.EmployeeCalendar
{
    public class EmployeeCalendarDTOAdd
    {
        public DateTime CalendarDate { get; set; }
        public int ProjectId { get; set; }
        public int WorkTypeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalTime { get; set; }
        public string? Description { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
