using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.Project
{
    public class ProjectChangeLogDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public List<ProjectChangeLogDTOList>? ProjectChangeLogList { get; set; }
        public override string ToString()
        {
            if(this.DataUpdateResponse == null)
            {
                return $"Project Change Log List is unavailable";
            }
            string status = this.DataUpdateResponse.Status.ToString();
            if(this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Project Change Log List here: {this.ProjectChangeLogList?.Count}";
            return status;
        }
    }

    public class ProjectChangeLogDTOList
    { 
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Descripton { get; set; }
        public int StatusCode { get; set; }
        public string? StatusNotes { get; set; }
        public string? IsDeleted { get; set; }
        public string? ValidFrom { get; set; }
        public string? ValidTo { get; set; }
        public string? RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
