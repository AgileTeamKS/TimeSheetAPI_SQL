using Newtonsoft.Json;

namespace Timesheet.Models.Common
{
    public class DataUpdateResponseWithId
    {
        public bool Status { get; set; }
        public string Description { get; set; }
        public int RecordCount { get; set; }
        public int InsertedId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
