using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.Lookup
{
    public class LookupDTOResponse
    {
        public DataUpdateResponse DataUpdateResponse { get; set; }
        public List<LookupDTOList> LookupList { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }

            string status = DataUpdateResponse.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Lookup List Count: {this.LookupList?.Count}";
            return status;
        }
    }

    public class LookupDTOList
    {
        public int LookupId { get; set; }
        public string TagName { get; set; }
        public int KeyValue { get; set; }
        public string KeyData {  get; set; }
        public string Note { get; set; }
        public string ReferenceTable { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
