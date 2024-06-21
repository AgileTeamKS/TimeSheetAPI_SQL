using Timesheet.Models.Masters.Calendar;

namespace Timesheet.Repository.Interface.Master
{
    public interface ICalendar
    {
        CalendarListResponse List(string userName);
    }
}
