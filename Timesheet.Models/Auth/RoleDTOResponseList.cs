using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Auth
{
    public class RoleDTOResponseList
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }

        public List<RoleResponseList>? RoleResponseList { get; set; }
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
            status += $"Role List Count:{this.RoleResponseList?.Count}";
            return status;
        }

    }

    public class RoleResponseList
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int TotalUsers { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
