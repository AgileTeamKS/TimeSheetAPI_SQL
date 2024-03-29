using Timesheet.Models.Masters.Employee;
using Timesheet.Models.Common;

namespace Timesheet.Repository.Interface.Master
{
    public interface IEmployee
    {
        EmployeeDTOResponse List(string userName);
        EmployeeDetailDTOResponse Add(EmployeeDTOAddDB employeeDTOAddDB);
        EmployeeDetailDTOResponse Edit(EmployeeDTOEditDB employeeDTOEditDB);
        EmployeeChangeLogDTOResponse ChangeLog_GetById(int employeeId, string userName);
        DataUpdateResponse Delete(int employeeId, string deletedBy, string deletedByIpAddress);
        EmployeeDetailDTOResponse Detail(int employeeId, string userName);
        EmployeeDeletedDTOResponse DeletedList(string userName);
    }
}
