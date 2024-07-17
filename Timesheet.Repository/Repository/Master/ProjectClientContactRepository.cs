using Dapper;
using System.Data;
using System.Data.SqlClient;
using Timesheet.DAL;
using Timesheet.Models.Common;
using Timesheet.Models.Masters.ProjectClientContact;
using Timesheet.Repository.Interface.Master;

namespace Timesheet.Repository.Repository.Master
{
    public class ProjectClientContactRepository : IProjectClientContact
    {
        private readonly AppConnectionString appConnectionString;

        public ProjectClientContactRepository (AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public ProjectClientContactDTOResponse List(int projectId, string userName)
        {
            ProjectClientContactDTOResponse response = new ProjectClientContactDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("ProjectClientContact_List_Admin", new { ProjectId = projectId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ProjectClientContactList = result.Read<ProjectClientContactDTOList>().ToList();
                }
            }
            return response;
        }

        public ProjectClientContactDeletedDTOResponse DeletedList(int projectId, string userName)
        {
            ProjectClientContactDeletedDTOResponse response = new ProjectClientContactDeletedDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("ProjectClientContact_Deleted_List_Admin", new { ProjectId = projectId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ProjectClientContactDeletedList = result.Read<ProjectClientContactDTOList>().ToList();
                }
            }
            return response;
        }

        public ProjectClientContactDetailDTOResponse Add(ProjectClientContactDTOAddDB projectClientContactDTOAddDB)
        {
            ProjectClientContactDetailDTOResponse response = new ProjectClientContactDetailDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("ProjectClientContact_Insert_Admin", projectClientContactDTOAddDB, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ProjectClientContactDetail = result.Read<ProjectClientContactDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public ProjectClientContactDetailDTOResponse Edit(ProjectClientContactDTOEditDB projectClientContactDTOEditDB)
        {
            ProjectClientContactDetailDTOResponse response = new ProjectClientContactDetailDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("ProjectClientContact_Update_Admin", projectClientContactDTOEditDB, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ProjectClientContactDetail = result.Read<ProjectClientContactDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public DataUpdateResponse Delete(int projectClientContactId, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);

            return connection.Query<DataUpdateResponse>("ProjectClientContact_Delete_Admin", new { ProjectClientContactId = projectClientContactId, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }

        public ProjectClientContactDetailDTOResponse Detail(int projectClientContactId, string userName)
        {
            ProjectClientContactDetailDTOResponse response = new ProjectClientContactDetailDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("ProjectClientContact_GetById_Admin", new { ProjectClientContactId = projectClientContactId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ProjectClientContactDetail = result.Read<ProjectClientContactDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public ProjectClientContactChangeLogDTOResponse ChangeLog_GetById(int projectClientContactId, string userName)
        {
            ProjectClientContactChangeLogDTOResponse response = new ProjectClientContactChangeLogDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("ProjectClientContactLog_GetByCode_Admin", new { ProjectClientContactId = projectClientContactId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ProjectClientConatctChangeLogList = result.Read<ProjectClientContactChangeLogDTOList>().ToList();
                }
            }
            return response;
        }

        
    }
}
