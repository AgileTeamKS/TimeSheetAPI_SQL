using Newtonsoft.Json;
using Timesheet.Models.Common;

namespace Timesheet.Models.Auth
{
    public class RoleDTOResponse
    {
        public List<RoleResponse>? RoleList { get; set; }
        public DataUpdateResponse? DataUpdateResponse { get; set; }
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
            status += $"Role List Count:{this.RoleList?.Count}";
            return status;
        }

    }

    public class RoleResponse
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
