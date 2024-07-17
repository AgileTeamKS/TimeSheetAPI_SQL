using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.Project
{
    public class ProjectDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public List<ProjectDTOList>? ProjectList { get; set; }
        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"Project List Unavailable";
            }
            string status = this.DataUpdateResponse.Status.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Project List Here: {this.ProjectList?.Count}";
            return status;
        }
    }

    public class ProjectDTOList
    {
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Description { get; set; }
        public int StatusCode { get; set; }
        public string? ProjectStatus { get; set; }
        public string? StatusNotes { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

