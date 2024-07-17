using Newtonsoft.Json;
using System.Xml;

namespace Timesheet.Models.Masters.Project
{
    public class ProjectDTOAddDB
    {
        public string? ProjectName { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public string? ClientContactsXML { get; set; }
        public int StatusCode { get; set; }
        public string? StatusNotes { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
