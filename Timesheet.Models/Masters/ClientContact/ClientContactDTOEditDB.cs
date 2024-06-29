using Newtonsoft.Json;

namespace Timesheet.Models.Masters.ClientContact
{
    public class ClientContactDTOEditDB
    {
        public int ClientContactId { get; set; }
        public string? ContactPersonName { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        public string? Email1 { get; set; }
        public string? Email2 { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
