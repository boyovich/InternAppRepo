using AutoMapper;
using InternApp.Domain.DTOs;
using InternApp.Domain.Entities;
using InternApp.Service.Service;
using InternApp.Service.Utils;
using Microsoft.OpenApi.Extensions;

namespace InternApp.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<CreateUserDTO,User>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.DateOfBirth, y => y.MapFrom(src =>
                    src.DateOfBirth.ToDateTime(TimeOnly.MinValue)
                ));
            CreateMap<UpdateUserDTO, User>()
                .ForMember(x => x.DateOfBirth, y => y.MapFrom(src =>
                    src.DateOfBirth.ToDateTime(TimeOnly.MinValue)
                ));
            CreateMap<Domain.Entities.User, UserDTO>()
                .ForMember(x => x.FullName, y => y.MapFrom(src =>
                    $"{src.FirstName} {src.LastName}"
                )).ForMember(x => x.Position, y => y.MapFrom(src =>
                   src.Position.GetEnumDescription()));         
        }
    }
}
