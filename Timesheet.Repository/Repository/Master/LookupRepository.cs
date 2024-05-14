using Dapper;
using System.Data;
using System.Data.SqlClient;
using Timesheet.DAL;
using Timesheet.Models.Common;
using Timesheet.Models.Masters.Lookup;
using Timesheet.Repository.Interface.Master;

namespace Timesheet.Repository.Repository.Master
{
    public class LookupRepository : ILookup
    {
        private readonly AppConnectionString appConnectionString;

        public LookupRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public LookupDTOResponse List(string userName)
        {
            LookupDTOResponse response = new LookupDTOResponse();
            using (IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = connection.QueryMultiple("LookupMaster_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status)
                {
                    response.LookupList = result.Read<LookupDTOList>().ToList();
                }
                
            }
            return response;
        }

        public LookupDetailDTOResponse Add(LookupDTOAddDB lookupDTOAddDB)
        {
            LookupDetailDTOResponse response = new LookupDetailDTOResponse();
            using (IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = connection.QueryMultiple("LookupMaster_Insert_Admin", lookupDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status)
                { 
                    response.LookupDetail = result.Read<LookupDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public LookupDetailDTOResponse Edit(LookupDTOEditDB lookupDTOEditDB)
        {
            LookupDetailDTOResponse response = new LookupDetailDTOResponse();
            using(IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = connection.QueryMultiple("LookupMaster_Update_Admin", lookupDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status)
                { 
                    response.LookupDetail = result.Read<LookupDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public LookupDetailDTOResponse Detail(int lookupId, string userName)
        {
            LookupDetailDTOResponse response = new LookupDetailDTOResponse();
            using (IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = connection.QueryMultiple("LookupMaster_GetByCode_Admin", new { UserName = userName, LookupId = lookupId }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (!response.DataUpdateResponse!.Status)
                { 
                    response.LookupDetail = result.Read<LookupDTODetail>().FirstOrDefault();
                }
            }
            return response;
        }

        public LookupDeletedDTOResponse DeletedList(string userName)
        {
            LookupDeletedDTOResponse response = new LookupDeletedDTOResponse();
            using (IDbConnection connection = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = connection.QueryMultiple("LookupMaster_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed && response.DataUpdateResponse!.Status)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponse>().FirstOrDefault();
                }
                if (response.DataUpdateResponse!.Status)
                { 
                    response.LookupList = result.Read<LookupDTOList>().ToList();
                }
            }
            return response;
        }
    }
}
