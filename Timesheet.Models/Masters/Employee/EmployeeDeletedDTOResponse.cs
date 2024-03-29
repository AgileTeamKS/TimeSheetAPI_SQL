using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheet.Models.Common;

namespace Timesheet.Models.Masters.Employee
{
    public class EmployeeDeletedDTOResponse
    {
        public DataUpdateResponse? DataUpdateResponse { get; set; }
        public List<EmployeeDTOList>? EmployeeList { get; set; }

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
            status += $"Deleted Employee List Count:{this.EmployeeList?.Count}";
            return status;
        }
    }
}
