using AutoMapper;
using LeaveManagamentSystem.Web.Data;
using LeaveManagamentSystem.Web.Models.LeaveTypes;

namespace LeaveManagamentSystem.Web.MappingProfiles {
    public class AutoMapperProfile : Profile{

        public AutoMapperProfile() {
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>();
                //.ForMember(x => x.NumberOfDays, y => y.MapFrom(z => z.NumberOfDays));
            CreateMap<LeaveTypeCreateVM, LeaveType>();
            CreateMap<LeaveTypeEditVM, LeaveType>().ReverseMap();
        }

    }
}
