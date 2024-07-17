using Newtonsoft.Json;

namespace Timesheet.Models.Masters.ProjectClientContact
{
    public class ProjectClientContactDTOAddDB
    {
        public int ProjectId { get; set; }
        public int ClientContactId { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
