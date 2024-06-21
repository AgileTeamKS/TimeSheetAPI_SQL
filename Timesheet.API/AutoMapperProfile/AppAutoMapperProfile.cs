using AutoMapper;
using Timesheet.Models.Masters.Employee;
using Timesheet.Models.Masters.EmployeeCalendar;
using Timesheet.Models.Masters.Lookup;

namespace Timesheet.API.AutoMapperProfile
{
    public class AppAutoMapperProfile : Profile
    {
        public AppAutoMapperProfile()
        {
            CreateMap<EmployeeDTOAdd, EmployeeDTOAddDB>();
            CreateMap<EmployeeDTOEdit, EmployeeDTOEditDB>();
            CreateMap<LookupDTOAdd,  LookupDTOAddDB>();
            CreateMap<LookupDTOEdit, LookupDTOEditDB>();
            CreateMap<EmployeeCalendarDTOAdd, EmployeeCalendarDTOAddDB>();
            CreateMap<EmployeeCalendarDTOEdit, EmployeeCalendarDTOEditDB>();
        }
    }
}
