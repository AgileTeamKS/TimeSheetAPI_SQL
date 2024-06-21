using Newtonsoft.Json;

namespace Timesheet.Models.Masters.Lookup
{
    public class LookupDTOEdit
    {
        public int LookupId { get; set; }
        public string ReferenceTable { get; set; }
        public string TagName { get; set; }
        public string KeyData { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
