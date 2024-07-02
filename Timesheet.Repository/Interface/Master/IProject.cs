using Timesheet.Models.Common;
using Timesheet.Models.Masters.Project;

namespace Timesheet.Repository.Interface.Master
{
    public interface IProject
    {
        ProjectDTOResponse List(string userName);
        ProjectDeletedDTOResponse DeletedList(string userName);
        ProjectDetailDTOResponse Add(ProjectDTOAddDB projectDTOAddDB);
        ProjectDetailDTOResponse Edit(ProjectDTOEditDB projectDTOEditDB);
        DataUpdateResponse Delete(int projectId, string deletedBy, string deletedByIpAddress);
        ProjectDetailDTOResponse Detail(int projectId, string userName);
        ProjectChangeLogDTOResponse ChangeLog_GetById(int projectId, string userName);
    }
}
