using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.Project
{
    public class ProjectDeletedDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public List<ProjectDTOList>? ProjectDeletedList { get; set; }
        public override string ToString()
        {
            if(this.DataUpdateResponse == null)
            {
                return $"Project Deleted List unavailable";
            }
            string status = this.DataUpdateResponse.Status.ToString();
            if(this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Project Deleted List here: {this.ProjectDeletedList?.Count}";
            return status;
        }
    }
}
