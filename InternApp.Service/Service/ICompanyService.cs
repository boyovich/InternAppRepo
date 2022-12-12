using InternApp.Domain.DTOs;
using InternApp.Domain.Entities;

namespace InternApp.Service.Service
{
    public interface ICompanyService
    {
        public IEnumerable<Company> GetAllCompanies();
        public Company CreateCompany(Company company);
        public Company UpdateCompany(string id, UpdateCompanyDTO companyDTO);
        public void DeleteCompany(string id); 
    }
}
