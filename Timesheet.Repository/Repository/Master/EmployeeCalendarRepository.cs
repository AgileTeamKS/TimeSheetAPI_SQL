using Dapper;
using System.Data;
using System.Data.SqlClient;
using Timesheet.DAL;
using Timesheet.Models.Common;
using Timesheet.Models.Masters.EmployeeCalendar;
using Timesheet.Repository.Interface.Master;

namespace Timesheet.Repository.Repository.Master
{
    public class EmployeeCalendarRepository : IEmployeeCalendar
    {
        private readonly AppConnectionString appConnectionString;

        public EmployeeCalendarRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public EmployeeCalendarDTOResponse List(string userName)
        {
            EmployeeCalendarDTOResponse response = new EmployeeCalendarDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("EmployeeCalendar_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status)
                {
                    response.EmployeeCalendarList = result.Read<EmployeeCalendarDTOList>().ToList();
                }
            }
            return response;
        }


        public EmployeeCalendarDetailDTOResponse Add(EmployeeCalendarDTOAddDB employeeCalendarDTOAddDB)
        {
            EmployeeCalendarDetailDTOResponse response = new EmployeeCalendarDetailDTOResponse();
            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("EmployeeCalendar_Insert_Admin", employeeCalendarDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status)
                {
                    response.EmployeeCalendarDetail = result.Read<EmployeeCalendarDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public EmployeeCalendarDetailDTOResponse Edit(EmployeeCalendarDTOEditDB employeeCalendarDTOEditDB)
        {
            EmployeeCalendarDetailDTOResponse response = new EmployeeCalendarDetailDTOResponse();
            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("EmployeeCalendar_Update_Admin", employeeCalendarDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status)
                {
                    response.EmployeeCalendarDetail = result.Read<EmployeeCalendarDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public EmployeeCalendarChangeLogDTOResponse ChangeLog_GetById(int employeeCalendarId, string userName)
        {
            EmployeeCalendarChangeLogDTOResponse response = new EmployeeCalendarChangeLogDTOResponse();
            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("EmployeeCalendarLog_GetByCode_Admin", new { EmployeeCalendarId = employeeCalendarId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status)
                {
                    response.EmployeeCalendarChangeLogList = result.Read<EmployeeCalendarChangeLogDTOList>().ToList();
                }
            }
            return response;
        }

        public EmployeeCalendarDetailDTOResponse Detail(int employeeCalendarId, string userName)
        {
            EmployeeCalendarDetailDTOResponse response = new EmployeeCalendarDetailDTOResponse();
            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("EmployeeCalendar_GetById_Admin", new { EmployeeCalendarId = employeeCalendarId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status)
                {
                    response.EmployeeCalendarDetail = result.Read<EmployeeCalendarDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public EmployeeCalendarDeletedDTOResponse DeletedList(string userName)
        {
            EmployeeCalendarDeletedDTOResponse response = new EmployeeCalendarDeletedDTOResponse();
            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("EmployeeCalendar_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.EmployeeCalendarDeletedList = result.Read<EmployeeCalendarDeletedDTOList>().ToList();
                }
            }
            return response;
        }

        public DataUpdateResponse Delete(int employeeCalendarId, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            return connection.Query<DataUpdateResponse>("EmployeeCalendar_Delete_Admin", new { EmployeeCalendarId = employeeCalendarId, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }
    }
}
