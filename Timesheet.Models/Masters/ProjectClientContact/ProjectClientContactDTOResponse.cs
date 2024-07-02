using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.ProjectClientContact
{
    public class ProjectClientContactDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public List<ProjectClientContactDTOList>? ProjectClientContactList { get; set; }
        public override string ToString()
        {
            if(this.DataUpdateResponse == null)
            {
                return $"Project Client Contact List unavailable";
            }
            string status = this.DataUpdateResponse.Status.ToString();
            if(this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Project Client Contact List here: {this.ProjectClientContactList?.Count}";
            return status;
        }
    }

    public class ProjectClientContactDTOList
    {
        public int ProjectClientContactId { get; set; }
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public int ClientContactId { get; set; }
        public string? ContactPersonName { get; set; }
        public string? Description { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
