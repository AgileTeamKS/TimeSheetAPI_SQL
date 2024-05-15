using Newtonsoft.Json;

namespace Timesheet.Models.Masters.Lookup
{
    public class LookupDTOAddDB
    {
        public string ReferenceTable { get; set; }
        public string TagName { get; set; }
        public string KeyData { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
