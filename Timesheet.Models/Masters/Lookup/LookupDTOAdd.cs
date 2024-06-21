using Newtonsoft.Json;

namespace Timesheet.Models.Masters.Lookup
{
    public class LookupDTOAdd
    {
        public string ReferenceTable { get; set; }
        public string TagName { get; set; }
        public string KeyData {  get; set; }
        public string Note { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
