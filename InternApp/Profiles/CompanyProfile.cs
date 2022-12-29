using AutoMapper;
using InternApp.Domain.DTOs;
using InternApp.Domain.Entities;

namespace InternApp.API.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile() {
            CreateMap<CreateCompanyDTO, Company>();
            CreateMap<UpdateCompanyDTO, Company>();
        }
    }
}
