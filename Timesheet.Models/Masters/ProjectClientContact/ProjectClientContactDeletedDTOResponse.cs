using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.ProjectClientContact
{
    public class ProjectClientContactDeletedDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public List<ProjectClientContactDTOList>? ProjectClientContactDeletedList {  get; set; }
        public override string ToString()
        {
            if(this.DataUpdateResponse == null)
            {
                return $"Project Client Contact Deleted List unavailable";
            }
            string status = this.DataUpdateResponse.Status.ToString();
            if(this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Project Client Contact Deleted List here: {this.ProjectClientContactDeletedList?.Count}";
            return status;
        }
    }
}
