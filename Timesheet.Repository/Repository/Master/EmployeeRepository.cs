using Dapper;
using System.Data;
using System.Data.SqlClient;
using Timesheet.Models.Masters.Employee;
using Timesheet.Repository.Interface.Master;
using Timesheet.DAL;
using Timesheet.Models.Common;

namespace Timesheet.Repository.Repository.Master
{
    public class EmployeeRepository : IEmployee
    {
        private readonly AppConnectionString appConnectionString;

        public EmployeeRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public EmployeeDTOResponse List(string userName)
        {
            EmployeeDTOResponse response = new EmployeeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Employee_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status)
                {
                    if (!result.IsConsumed)
                    {
                        response.EmployeeList = result.Read<EmployeeDTOList>().ToList();
                    }
                }
            }
            return response;
        }

        public EmployeeDetailDTOResponse Add(EmployeeDTOAddDB employeeDTOAddDB)
        {
            EmployeeDetailDTOResponse response = new EmployeeDetailDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Employee_Insert_Admin", employeeDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status && !result.IsConsumed)
                {
                    response.EmployeeDetail = result.Read<EmployeeDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public EmployeeDetailDTOResponse Edit(EmployeeDTOEditDB employeeDTOEditDB)
        {
            EmployeeDetailDTOResponse response = new EmployeeDetailDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Employee_Update_Admin", employeeDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status && !result.IsConsumed )
                {
                    response.EmployeeDetail = result.Read<EmployeeDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public EmployeeChangeLogDTOResponse ChangeLog_GetById(int employeeId, string userName)
        {
            EmployeeChangeLogDTOResponse response = new EmployeeChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("EmployeeLog_GetByCode_Admin", new { EmployeeId = employeeId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status && !result.IsConsumed)
                {
                    response.EmployeeChangeLogList = result.Read<EmployeeChangeLogDTOList>().ToList();
                }    
            }
            return response;
        }

        public DataUpdateResponse Delete(int employeeId, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            return cnn.Query<DataUpdateResponse>("Employee_Delete_Admin", new { EmployeeId = employeeId, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }

        public EmployeeDetailDTOResponse Detail(int employeeId, string userName)
        {
            EmployeeDetailDTOResponse response = new EmployeeDetailDTOResponse();
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = cnn.QueryMultiple("Employee_GetById_Admin", new { EmployeeId = employeeId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status && !result.IsConsumed)
                {
                    response.EmployeeDetail = result.Read<EmployeeDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public EmployeeDeletedDTOResponse DeletedList(string userName)
        {
            EmployeeDeletedDTOResponse response = new EmployeeDeletedDTOResponse();
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = cnn.QueryMultiple("Employee_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status && !result.IsConsumed)
                {
                    response.EmployeeList = result.Read<EmployeeDTOList>().ToList();
                }
            }
            return response;
        }
    }
}
