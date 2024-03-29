using AutoMapper;
using Timesheet.Models.Masters.Employee;

namespace Timesheet.API.AutoMapperProfile
{
    public class AppAutoMapperProfile : Profile
    {
        public AppAutoMapperProfile()
        {
            CreateMap<EmployeeDTOAdd, EmployeeDTOAddDB>();
            CreateMap<EmployeeDTOEdit, EmployeeDTOEditDB>();
        }
    }
}
