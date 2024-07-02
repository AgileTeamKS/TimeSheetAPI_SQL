using Timesheet.Models.Common;
using Timesheet.Models.Masters.ClientContact;

namespace Timesheet.Repository.Interface.Master
{
    public interface IClientContact
    {
        ClientContactDTOResponse List(int clientId, string userName);
        ClientContactDeletedDTOResponse DeletedList(int clientId, string userName);
        ClientContactDetailDTOResponse Add(ClientContactDTOAddDB clientContactDTOAddDB);
        ClientContactDetailDTOResponse Edit(ClientContactDTOEditDB clientContactDTOEditDB);
        DataUpdateResponse Delete(int clientContactId, string deletedBy, string deletedByIpAddress);
        ClientContactDetailDTOResponse Detail(int clientContactId, string userName);
        ClientContactChangeLogDTOResponse ChangeLog_GetById(int clientContactId, string userName);
    }
}
