using Dapper;
using System.Data;
using System.Data.SqlClient;
using Timesheet.DAL;
using Timesheet.Models.Common;
using Timesheet.Models.Masters.ClientContact;
using Timesheet.Repository.Interface.Master;

namespace Timesheet.Repository.Repository.Master
{
    public class ClientContactRepository : IClientContact
    {
        private readonly AppConnectionString appConnectionString;

        public ClientContactRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public ClientContactDTOResponse List(int clientId, string userName)
        {
            ClientContactDTOResponse response = new ClientContactDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("ClientContact_List_Admin", new { ClientId = clientId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ClientContactList = result.Read<ClientContactDTOList>().ToList();
                }
            }
            return response;
        }

        public ClientContactDeletedDTOResponse DeletedList(int clientId, string userName)
        {
            ClientContactDeletedDTOResponse response = new ClientContactDeletedDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("ClientContact_Deleted_List_Admin", new { ClientId = clientId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ClientContactDeletedList = result.Read<ClientContactDTOList>().ToList();
                }
            }
            return response;
        }

        public ClientContactDetailDTOResponse Add(ClientContactDTOAddDB clientContactDTOAddDB)
        {
            ClientContactDetailDTOResponse response = new ClientContactDetailDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("ClientContact_Insert_Admin", clientContactDTOAddDB, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ClientContactDetail = result.Read<ClientContactDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public ClientContactDetailDTOResponse Edit(ClientContactDTOEditDB clientContactDTOEditDB)
        {
            ClientContactDetailDTOResponse response = new ClientContactDetailDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("ClientContact_Update_Admin", clientContactDTOEditDB, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault(); 
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ClientContactDetail = result.Read<ClientContactDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public DataUpdateResponse Delete(int clientContactId, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            return connection.Query<DataUpdateResponse>("ClientContact_Delete_Admin", new { ClientContactId = clientContactId, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }

        public ClientContactDetailDTOResponse Detail(int clientContactId, string userName)
        {
            ClientContactDetailDTOResponse response = new ClientContactDetailDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("ClientContact_GetById_Admin", new { ClientContactId = clientContactId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ClientContactDetail = result.Read<ClientContactDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public ClientContactChangeLogDTOResponse ChangeLog_GetById(int clientContactId, string userName)
        {
            ClientContactChangeLogDTOResponse response = new ClientContactChangeLogDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("ClientContactLog_GetByCode_Admin", new { ClientContactId = clientContactId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status)
                {
                    response.ClientContactChangeLogList = result.Read<ClientContactChangeLogDTOList>().ToList();
                }
            }
            return response;
        }
    }
}
