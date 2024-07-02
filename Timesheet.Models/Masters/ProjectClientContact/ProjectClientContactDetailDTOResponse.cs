using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.ProjectClientContact
{
    public class ProjectClientContactDetailDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public ProjectClientContactDTODetail? ProjectClientContactDetail { get; set; }
        public override string ToString()
        {
            if(this.DataUpdateResponse == null)
            {
                return $"Project Client Contact Detail unavailable";
            }
            string status = this.DataUpdateResponse.Status.ToString();
            if(this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Project Client Contact Detail here: {this.ProjectClientContactDetail}";
            return status;
        }
    }
    public class ProjectClientContactDTODetail
    {
        public int ProjectClientContactId { get; set; }
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public int ClientContactId { get; set; }
        public string? ContactPersonName { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy {  get; set; }
        public string? CreatedByIpAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public string? DeletedByIpAddress { get; set; }
        public DateTime? DeletedOn { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
