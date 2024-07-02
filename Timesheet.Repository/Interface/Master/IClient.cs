using Timesheet.Models.Common;
using Timesheet.Models.Masters.Client;

namespace Timesheet.Repository.Interface.Master
{
    public interface IClient
    {
        ClientDTOResponse List(string userName);
        ClientDeletedDTOResponse DeletedList(string userName);
        ClientDetailDTOResponse Add(ClientDTOAddDB clientDTOAddDB);
        ClientDetailDTOResponse Edit(ClientDTOEditDB clientDTOEditDB);
        DataUpdateResponse Delete(int clientId, string deletedBy, string deletedByIpAddress);
        ClientDetailDTOResponse Detail(int clientId, string userName);
        ClientChangeLogDTOResponse ChangeLog_GetById(int clientId, string userName);
    }
}
