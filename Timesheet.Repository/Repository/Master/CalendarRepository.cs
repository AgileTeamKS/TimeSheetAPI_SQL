using Dapper;
using System.Data;
using System.Data.SqlClient;
using Timesheet.DAL;
using Timesheet.Models.Common;
using Timesheet.Models.Masters.Calendar;
using Timesheet.Repository.Interface.Master;

namespace Timesheet.Repository.Repository.Master
{
    public class CalendarRepository : ICalendar
    {
        private readonly AppConnectionString appConnectionString;

        public CalendarRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public CalendarListResponse List(string userName)
        {
            CalendarListResponse response = new CalendarListResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("Calendar_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status)
                {
                    response.CalendarList = result.Read<CalendarList>().ToList();
                }
            }
            return response;
        }
    }
}
