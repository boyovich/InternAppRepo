using InternApp.Domain.DTOs;
using InternApp.Domain.Entities;

namespace InternApp.Service.Service
{
    public interface ICompanyService
    {
        public IEnumerable<Company> GetAllCompanies();
        public Company CreateCompany(Company company);
        public Company UpdateCompany(Guid id, UpdateCompanyDTO companyDTO);
        public void DeleteCompany(Guid id); 
    }
}
