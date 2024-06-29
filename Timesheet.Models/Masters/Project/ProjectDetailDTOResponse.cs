using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.Project
{
    public class ProjectDetailDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public ProjectDTODetail? ProjectDetail { get; set; }
        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"Project Detail unavailable";
            }
            string status = this.DataUpdateResponse.Status.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Project Detail here: {this.ProjectDetail}";
            return status;
        }
    }

    public class ProjectDTODetail
    {
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public int StatusCode { get; set; }
        public string? ProjectStatus { get; set; }
        public string? StatusNotes { get; set; }
        public string? CreatedBy { get; set; }
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
