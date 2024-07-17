using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.ClientContact
{
    public class ClientContactChangeLogDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public List<ClientContactChangeLogDTOList>? ClientContactChangeLogList { get; set; }
        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"Client Contact Change Log is unavailable";
            }
            string status = this.DataUpdateResponse.Status.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Client Contact Change Log here: {this.ClientContactChangeLogList?.Count}";
            return status;
        }
    }

    public class ClientContactChangeLogDTOList
    {
        public int ClientContactId { get; set; }
        public int ClientId {  get; set; }
        public string? ClientName {  get; set; }
        public string? ContactPersonName { get; set; }
        public string? Mobile1 {  get; set; }
        public string? Mobile2 { get; set; }
        public string? Email1 {  get; set; }
        public string? Email2 { get; set; }
        public string? IsDeleted { get; set; }
        public string? ValidFrom { get; set; }
        public string? ValidTo { get; set; }
        public string? RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
