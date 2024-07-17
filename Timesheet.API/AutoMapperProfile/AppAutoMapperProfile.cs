using AutoMapper;
using Timesheet.Models.Masters.Client;
using Timesheet.Models.Masters.ClientContact;
using Timesheet.Models.Masters.Employee;
using Timesheet.Models.Masters.EmployeeCalendar;
using Timesheet.Models.Masters.Lookup;
using Timesheet.Models.Masters.Project;
using Timesheet.Models.Masters.ProjectClientContact;

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
            CreateMap<ClientDTOAdd, ClientDTOAddDB>();
            CreateMap<ClientDTOEdit, ClientDTOEditDB>();
            CreateMap<ClientContactDTOAdd, ClientContactDTOAddDB>();
            CreateMap<ClientContactDTOEdit, ClientContactDTOEditDB>();
            CreateMap<ProjectDTOAdd, ProjectDTOAddDB>();
            CreateMap<ProjectDTOEdit, ProjectDTOEditDB>();
            CreateMap<ProjectClientContactDTOAdd, ProjectClientContactDTOAddDB>();
            CreateMap<ProjectClientContactDTOEdit, ProjectClientContactDTOEditDB>();
        }
    }
}
