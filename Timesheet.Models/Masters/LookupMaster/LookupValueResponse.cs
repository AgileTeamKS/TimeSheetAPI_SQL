using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.LookupMaster
{
    public class LookupGetByTagNameDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }  
        public List<LookupGetByTagNameDTOList>? LookupGetByTagNameList {  get; set; }
        public override string ToString()
        {
            if(this.DataUpdateResponse == null) 
            {
                return $"No Status Available";
            }
            string status = DataUpdateResponse.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Lookup Get By Tag List Count:{this.LookupGetByTagNameList?.Count}";
            return status;

        }

    }

    public class LookupGetByTagNameDTOList
    {
        public string? TagName { get; set; }
        public int KeyValue { get; set; }
        public string? KeyData { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
