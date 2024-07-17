using Dapper;
using System.Data;
using System.Data.SqlClient;
using Timesheet.DAL;
using Timesheet.Models.Common;
using Timesheet.Models.Masters.Client;
using Timesheet.Models.Masters.ClientContact;
using Timesheet.Repository.Interface.Master;

namespace Timesheet.Repository.Repository.Master
{
    public class ClientRepository : IClient
    {
        private readonly AppConnectionString appConnectionString;

        public ClientRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public ClientDTOResponse List(string userName)
        {
            ClientDTOResponse response = new ClientDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("Client_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ClientList = result.Read<ClientDTOList>().ToList();
                }
            }
            return response;
        }

        public ClientDeletedDTOResponse DeletedList(string userName)
        {
            ClientDeletedDTOResponse response = new ClientDeletedDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("Client_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ClientDeletedList = result.Read<ClientDTOList>().ToList();
                }
            }
            return response;
        }

        public ClientDetailDTOResponse Add(ClientDTOAddDB clientDTOAddDB)
        {
            ClientDetailDTOResponse response = new ClientDetailDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("Client_Insert_Admin", clientDTOAddDB, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ClientDetail = result.Read<ClientDTODetail>().FirstOrDefault();
                    response.ClientContactList = result.Read<ClientContactDTOList>().ToList();
                }
            }
            return response;
        }

        public ClientDetailDTOResponse Edit(ClientDTOEditDB clientDTOEditDB)
        {
            ClientDetailDTOResponse response = new ClientDetailDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("Client_Update_Admin", clientDTOEditDB, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ClientDetail = result.Read<ClientDTODetail>().FirstOrDefault();
                    response.ClientContactList = result.Read<ClientContactDTOList>().ToList();
                }
            }
            return response;
        }

        public DataUpdateResponse Delete(int clientId, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            return connection.Query<DataUpdateResponse>("Client_Delete_Admin", new { ClientId = clientId, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }

        public ClientDetailDTOResponse Detail(int clientId, string userName)
        {
            ClientDetailDTOResponse response = new ClientDetailDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("Client_GetById_Admin", new { ClientId = clientId, UserName = userName, }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ClientDetail = result.Read<ClientDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public ClientChangeLogDTOResponse ChangeLog_GetById(int clientId, string userName)
        {
            ClientChangeLogDTOResponse response = new ClientChangeLogDTOResponse();

            using IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString);
            {
                var result = connection.QueryMultiple("ClientLog_GetByCode_Admin", new { ClientId = clientId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if(!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if(response.DataUpdateResponse!.Status)
                {
                    response.ClientChangeLogList = result.Read<ClientChangeLogDTOList>().ToList();  
                }
            }
            return response;
        }
    }
}
