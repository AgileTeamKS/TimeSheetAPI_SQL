using Newtonsoft.Json;
using System.Xml;

namespace Timesheet.Models.Masters.Project
{
    public class ProjectDTOAdd
    {
        public string? ProjectName { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description {  get; set; }
        public XmlElement? ClientContactsXML { get; set; }
        public int StatusCode {  get; set; }
        public string? StatusNotes { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
