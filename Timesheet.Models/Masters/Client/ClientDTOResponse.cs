using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.Client
{
    public class ClientDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public List<ClientDTOList>? ClientList { get; set; }
        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"Client List Unavailable";
            }
            string status = DataUpdateResponse.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Client List Count: {this.ClientList?.Count}";
            return status;
        }
    }

    public class ClientDTOList
    {
        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public int ClientTypeId { get; set; }
        public string? ClientType { get; set; }
        public int CityId { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
