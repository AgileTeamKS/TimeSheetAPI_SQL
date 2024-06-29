using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.ClientContact
{
    public class ClientContactDeletedDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public List<ClientContactDTOList>? ClientDeletedList { get; set; }
        public override string ToString()
        {
            if(this.DataUpdateResponse == null)
            {
                return $"Client Deleted List unavailable";
            }
            string status = this.DataUpdateResponse.Status.ToString();
            if(this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Client Deleted List: {ClientDeletedList?.Count}";
            return status;
        }
    }
}
