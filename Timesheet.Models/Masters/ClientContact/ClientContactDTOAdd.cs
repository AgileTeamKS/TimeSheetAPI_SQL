using Newtonsoft.Json;

namespace Timesheet.Models.Masters.ClientContact
{
    public class ClientContactDTOAdd
    {
        public int ClientId { get; set; }
        public string? ContactPersonName { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        public string? Email1 { get; set; }
        public string? Email2 { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
