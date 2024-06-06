using Timesheet.Models.Masters.Lookup;
using Timesheet.Models.Masters.LookupMaster;

namespace Timesheet.Repository.Interface.Master
{
    public interface ILookup
    {
        LookupDTOResponse List(string userName);
        LookupDetailDTOResponse Add(LookupDTOAddDB lookupDTOAddDB);
        LookupDetailDTOResponse Edit(LookupDTOEditDB lookupDTOEditDB);
        LookupDetailDTOResponse Detail(int lookupId, string userName);
        LookupDeletedDTOResponse DeletedList(string userName);
        LookupGetByTagNameDTOResponse LookupGetByTagName(string tagName, string userName);
    }
}
