using AutoMapper;
using Google.App.Core.Dtos;
using Google.Models;

namespace Google.App.Core
{
    public class GoogleProfile : Profile
    {
        public GoogleProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, ManagerDto>()
                .ForMember(dest => dest.EmployeeDtos, from => from.MapFrom(x=>x.ManagerEmployees))
                .ReverseMap();
            CreateMap<Employee, EmployeePersonalInfoDto>().ReverseMap();
        }
    }
}
