using Microsoft.Extensions.DependencyInjection;
using Timesheet.Repository.Interface.Auth;
using Timesheet.Repository.Interface.Master;
using Timesheet.Repository.Repository.Auth;
using Timesheet.Repository.Repository.Master;

namespace Timesheet.Repository
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            DAL.Configure.ConfigureServices(services, connectionString);
            //Authenticate Repository and Token options as dependency injection
            services.AddScoped<IEmployee, EmployeeRepository>();
            services.AddScoped<IUserAccount, AccountRepository>();
            services.AddScoped<ILookup, LookupRepository>();
            services.AddScoped<IEmployeeCalendar, EmployeeCalendarRepository>();
        }
    }
}
