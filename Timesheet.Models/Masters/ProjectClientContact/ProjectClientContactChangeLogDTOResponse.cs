using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.ProjectClientContact
{
    public class ProjectClientContactChangeLogDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public List<ProjectClientContactChangeLogDTOList>? ProjectClientConatctChangeLogList { get; set; }
        public override string ToString()
        {
            if(this.DataUpdateResponse == null)
            {
                return $"Project Client Contact Change Log is unavailable";
            }
            string status = this.DataUpdateResponse.Status.ToString();
            if(this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Project Client Contact Change Log here: {this.ProjectClientConatctChangeLogList?.Count}";
            return status;
        }
    }

    public class ProjectClientContactChangeLogDTOList
    {
        public int ProjectClientContactId { get; set; }
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public int ClientContactId { get; set; }
        public string? ContactPersonName { get; set; }
        public string? Description { get; set; }
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
