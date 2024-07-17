using Newtonsoft.Json;

namespace Timesheet.Models.Masters.Client
{
    public class ClientDTOAdd
    {
        public string? ClientName { get; set; }
        public int ClientTypeId { get; set; }
        public string? Address { get; set; }
        public int CityId { get; set; }
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
