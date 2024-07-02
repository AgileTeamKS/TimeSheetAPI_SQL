using Dapper;
using System.Data;
using System.Data.SqlClient;
using Timesheet.DAL;
using Timesheet.Models.Common;
using Timesheet.Models.Masters.Project;
using Timesheet.Repository.Interface.Master;

namespace Timesheet.Repository.Repository.Master
{
    public class ProjectRepository : IProject
    {
        private readonly AppConnectionString appConnectionString;

        public ProjectRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public ProjectDTOResponse List(string userName)
        {
            ProjectDTOResponse response = new ProjectDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("Project_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ProjectList = result.Read<ProjectDTOList>().ToList();
                }
            }
            return response;
        }

        public ProjectDeletedDTOResponse DeletedList(string userName)
        {
            ProjectDeletedDTOResponse response = new ProjectDeletedDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("Project_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ProjectDeletedList = result.Read<ProjectDTOList>().ToList();
                }
            }
            return response;
        }

        public ProjectDetailDTOResponse Add(ProjectDTOAddDB projectDTOAddDB)
        {
            ProjectDetailDTOResponse response = new ProjectDetailDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("Project_Insert_Admin", projectDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ProjectDetail = result.Read<ProjectDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public ProjectDetailDTOResponse Edit(ProjectDTOEditDB projectDTOEditDB)
        {
            ProjectDetailDTOResponse response = new ProjectDetailDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("Project_Update_Admin", projectDTOEditDB, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ProjectDetail = result.Read<ProjectDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public DataUpdateResponse Delete(int projectId, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);

            return connection.Query<DataUpdateResponse>("Project_Delete_Admin", new { ProjectId = projectId, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }

        public ProjectDetailDTOResponse Detail(int projectId, string userName)
        {
            ProjectDetailDTOResponse response = new ProjectDetailDTOResponse();
            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("Project_GetById_Admin", new { ProjectId = projectId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ProjectDetail = result.Read<ProjectDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public ProjectChangeLogDTOResponse ChangeLog_GetById(int projectId, string userName)
        {
            ProjectChangeLogDTOResponse response = new ProjectChangeLogDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("ProjectLog_GetByCode_Admin", new { ProjectId = projectId, userName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ProjectChangeLogList = result.Read<ProjectChangeLogDTOList>().ToList();
                }
            }
            return response;
        }
    }
}
