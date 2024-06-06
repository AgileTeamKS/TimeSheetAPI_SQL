using Timesheet.Models.Common;
using Timesheet.Models.Masters.EmployeeCalendar;

namespace Timesheet.Repository.Interface.Master
{
    public interface IEmployeeCalendar
    {
        EmployeeCalendarDTOResponse List(string userName);
        EmployeeCalendarDeletedDTOResponse DeletedList(string userName);
        EmployeeCalendarDetailDTOResponse Add(EmployeeCalendarDTOAddDB employeeCalendarDTOAddDB);
        EmployeeCalendarDetailDTOResponse Edit(EmployeeCalendarDTOEditDB employeeCalendarDTOEditDB);
        EmployeeCalendarChangeLogDTOResponse ChangeLog_GetById(int employeeCalendarId, string userName);
        EmployeeCalendarDetailDTOResponse Detail(int employeeCalendarId, string userName);
        DataUpdateResponse Delete(int employeeCalendarId, string deletedBy, string deletedByIpAddress);
    }
}
