using Microsoft.Extensions.DependencyInjection;

namespace Timesheet.DAL
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services,string connectionString)
        {
            services.AddSingleton<AppConnectionString>(new AppConnectionString(connectionString));
        }
    }
}
