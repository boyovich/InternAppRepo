using InternApp.Domain.DTOs;
using InternApp.Domain.Entities;
using InternApp.Domain.Persistance;

namespace InternApp.Service.Service
{
    public class CompanyService : ICompanyService
    {
        private InternDbContext _context;
        public CompanyService(InternDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _context.Companies.OrderBy(c => c.Name).ToList();
        }

        public Company CreateCompany(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
            return company;
        }

        public void DeleteCompany(Guid id)
        {
            _context.Remove(_context.Companies.Single(s => s.Id == id));
            _context.SaveChanges();
        }

        public Company UpdateCompany(Guid id, UpdateCompanyDTO companyDTO)
        {
            Company company = _context.Companies.Single(c => c.Id == id);
            company.Name = companyDTO.Name;
            company.City = companyDTO.City;
            company.Country = companyDTO.Country;
            _context.SaveChanges();
            return company;
        }
    }
}
