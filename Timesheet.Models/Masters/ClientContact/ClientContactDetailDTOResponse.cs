using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.ClientContact
{
    public class ClientContactDetailDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public ClientContactDTODetail? ClientContactDetail { get; set; }
        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"Client Contact Detail unavailable";
            }
            string status = this.DataUpdateResponse.Status.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Client Contact Detail: {this.ClientContactDetail}";
            return status;
        }
    }

    public class ClientContactDTODetail
    {
        public string? ContactPersonName { get; set; }
        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        public string? Email1 { get; set; }
        public string? Email2 { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedByIpAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedByIpAddress { get; set; }
        public DateTime ModifiedOn { get; set; }
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
