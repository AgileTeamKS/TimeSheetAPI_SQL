using Newtonsoft.Json;

namespace Timesheet.Models.Masters.ProjectClientContact
{
    public class ProjectClientContactDTOEditDB
    {
        public int ProjectClientContactId { get; set; }
        public int ClientContactId { get; set; }
        public string? Description { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
