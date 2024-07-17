using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.Client
{
    public class ClientDeletedDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public List<ClientDTOList>? ClientDeletedList { get; set; }
        public override string ToString()
        {
            if(this.DataUpdateResponse == null)
            {
                return $"Client Deleted List Unavailable";
            }
            string status = DataUpdateResponse.ToString();
            if(this.DataUpdateResponse.Status == false)
            {
                return status ;
            }
            status += $"Deleted Client List: {this.ClientDeletedList?.Count}";
            return status;
        }
    }
}
