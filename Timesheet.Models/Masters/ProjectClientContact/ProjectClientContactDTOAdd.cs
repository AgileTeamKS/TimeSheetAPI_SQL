using Newtonsoft.Json;

namespace Timesheet.Models.Masters.ProjectClientContact
{
    public class ProjectClientContactDTOAdd
    {
        public int ProjectId { get; set; }
        public int ClientContactId { get; set; }
        public string? Description { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
