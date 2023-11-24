using AutoMapper;
using BlazorWasmAppCookieAuth.Shared;

namespace BlazorWasmAppCookieAuth.Client.ViewModels
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, VMEditEmployee>()
                .ForMember(dest => dest.ConfirmEmail,
                            opt => opt.MapFrom(src => src.Email));

            CreateMap<VMEditEmployee, Employee>();
        }
    }
}
