using Newtonsoft.Json;

namespace Timesheet.Models.Masters.ClientContact
{
    public class ClientContactDTOAddDB
    {
        public int ClientId { get; set; }
        public string? ContactPersonName { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        public string? Email1 { get; set; }
        public string? Email2 { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
