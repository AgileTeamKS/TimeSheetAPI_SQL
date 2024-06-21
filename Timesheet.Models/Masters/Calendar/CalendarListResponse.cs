using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.Calendar
{
    public class CalendarListResponse
    {
        public DataUpdateResponse DataUpdateResponse { get; set; }
        public List<CalendarList> CalendarList { get; set; }
        public override string ToString()
        {
            if(this.DataUpdateResponse == null)
            {
                return $"No Response Available";
            }
            string status = DataUpdateResponse.ToString();
            if(this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Calendar List Count {this.CalendarList?.Count}";
            return status;
        }
    }

    public class CalendarList
    {
        public DateTime CalendarDate { get; set; }
        public int CalendarId { get; set; }
        public string? Day { get; set; }
        public string? Month { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
