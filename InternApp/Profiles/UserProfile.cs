using AutoMapper;
using InternApp.Domain.DTOs;
using InternApp.Domain.Entities;
using InternApp.Service.Service;

namespace InternApp.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<User, CreateUserDTO>().ReverseMap()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.DateOfBirth, y => y.MapFrom(src =>
                    src.DateOfBirth.ToDateTime(TimeOnly.MinValue)
                ));
            CreateMap<User, UpdateUserDTO>().ReverseMap()
                .ForMember(x => x.DateOfBirth, y => y.MapFrom(src =>
                    src.DateOfBirth.ToDateTime(TimeOnly.MinValue)
                )); 
        }
    }
}
