using Timesheet.Models.Common;
using Timesheet.Models.Masters.ProjectClientContact;

namespace Timesheet.Repository.Interface.Master
{
    public interface IProjectClientContact
    {
        ProjectClientContactDTOResponse List(int projectId, string userName);
        ProjectClientContactDeletedDTOResponse DeletedList(int projectId, string userName);
        ProjectClientContactDetailDTOResponse Add(ProjectClientContactDTOAddDB projectClientContactDTOAddDB);
        ProjectClientContactDetailDTOResponse Edit(ProjectClientContactDTOEditDB projectClientContactDTOEditDB);
        DataUpdateResponse Delete(int projectClientContactId, string deletedBy, string deletedByIpAddress);
        ProjectClientContactDetailDTOResponse Detail(int projectClientContactId, string userName);
        ProjectClientContactChangeLogDTOResponse ChangeLog_GetById(int projectClientContactId, string userName);
    }
}
