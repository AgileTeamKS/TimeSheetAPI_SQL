using Newtonsoft.Json;

namespace Timesheet.Models.Masters.Project
{
    public class ProjectDTOAdd
    {
        public string? ProjectName { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public string? ClientContactsXML { get; set; } //XML
        public int StatusCode { get; set; }
        public string? StatusNotes { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ClientContact
    {
        public int ClientContactId { get; set; }
        public string? Description { get; set; }
    }
}
