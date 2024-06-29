using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.Client
{
    public class ClientDetailDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public ClientDTODetail? ClientDetail { get; set; }
        public override string ToString()
        {
            if(this.DataUpdateResponse == null)
            {
                return $"Client Detail unavailable";
            }
            string status = DataUpdateResponse.Status.ToString();
            if(this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Client Details here: {this.ClientDetail}";
            return status;
        }
    }

    public class ClientDTODetail
    {
        public int ClientId { get; set; }
        public string? ClientName { get; set; } 
        public int ClientTypeId { get; set; }
        public string? ClientType { get; set;}
        public int CityId { get; set; }
        public string? City {  get; set; }
        public string? Address { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedByIpAddress { get; set; }
        public DateTime CreatedOn {  get; set; }
        public string? ModifiedBy {  get; set; }
        public string? ModifiedByIpAddress { get; set; }
        public DateTime ModifiedOn { get; set;}
        public string? DeletedBy { get; set; }
        public string? DeletedByIpAddress { get; set; }
        public DateTime DeletedOn { get; set; }
        public string? IsDeleted { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
