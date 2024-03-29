namespace Timesheet.DAL
{
    public class AppConnectionString
    {
        public string ConnectionString { get; }
        public AppConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
