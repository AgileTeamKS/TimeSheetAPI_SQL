using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.ClientContact
{
    public class ClientContactDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public List<ClientContactDTOList>? ClientContactList { get; set; }
        public override string ToString()
        {
            if(this.DataUpdateResponse == null)
            {
                return $"Client Contact List unavailable";
            }
            string status = this.DataUpdateResponse.Status.ToString();
            if(this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Client Contact List: {ClientContactList?.Count}";
            return status;
        }
    }

    public class ClientContactDTOList
    {
        public int ClientContactId { get; set; }
        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public string? ContactPersonName { get; set;}
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
