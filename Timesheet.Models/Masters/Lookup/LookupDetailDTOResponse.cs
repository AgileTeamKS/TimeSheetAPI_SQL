using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.Lookup
{
    public class LookupDetailDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public LookupDTODetail? LookupDetail { get; set; }

        public override string ToString()
        {
            if (DataUpdateResponse == null)
            {
                return $"No Status Available";
            }

            string status = DataUpdateResponse.ToString();

            if (DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Lookup Details:{this.LookupDetail}";
            return status;
        }

    }

    public class LookupDTODetail
    {
        public int LookupId { get; set; }
        public string? TagName { get; set; }
        public int KeyValue { get; set; }
        public string? KeyData { get; set; }
        public string? Note { get; set; }
        public string? ReferenceTable { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedByIpAddress { get; set; }
        public string? CreatedOn { get; set; }
        public string? IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public string? DeletedByIpAddress { get; set; }
        public string? DeletedOn { get; set; }
        public string? ModifiedOn { get; set; }
        public string? ModifiedBy {  get; set; }
        public string? ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
