using Newtonsoft.Json;

namespace Timesheet.Models.Masters.Project
{
    public class ProjectDTOEditDB
    {
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? ClientName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public int StatusCode { get; set; }
        public string? StatusNotes { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
