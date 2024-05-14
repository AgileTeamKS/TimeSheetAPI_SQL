using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.Lookup
{
    public class LookupDeletedDTOResponse
    {
        public DataUpdateResponse DataUpdateResponse { get; set; }
        public List<LookupDTOList> LookupList { get; set; }
        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No Status Available";
            }
            string status = DataUpdateResponse.ToString();

            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }

            status += $"Deleted Lookup List Count: {this.LookupList?.Count}";
            return status;
        }
    }
}
