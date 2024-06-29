using Newtonsoft.Json;

namespace Timesheet.Models.Masters.Client
{
    public class ClientDTOEdit
    {
        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public int ClientTypeId { get; set; }
        public string? Address { get; set; }
        public int CityId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
