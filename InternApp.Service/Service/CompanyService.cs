using InternApp.Domain.DTOs;
using InternApp.Domain.Entities;
using InternApp.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace InternApp.Service.Service
{
    public class CompanyService : ICompanyService
    {
        private InternDbContext _context;
        public CompanyService(InternDbContext context)
        {
            _context = context;
        }
        public PaginationResponse<Company> GetAllCompanies()
        {
            return new PaginationResponse<Company> { ResponseList = _context.Companies.OrderBy(c => c.Id).ToList(), Count = _context.Companies.Count() };
        }

        public PaginationResponse<Company> GetCompanies(PaginationRequest request)
        {
            IQueryable<Company> companies = _context.Companies.AsQueryable();
            switch (request.SortBy)
            {
                case "Nameascend":
                    companies = companies.OrderBy(c => c.Name);
                    break;
                case "Cityascend":
                    companies = companies.OrderBy(c => c.City);
                    break;
                case "Countryascend":
                    companies = companies.OrderBy(c => c.Country);
                    break;
                case "NumberofUsersascend":
                    companies = companies.OrderBy(c => c.Users.Count());
                    break;
                case "Namedescend":
                    companies = companies.OrderByDescending(c => c.Name);
                    break;
                case "Citydescend":
                    companies = companies.OrderByDescending(c => c.City);
                    break;
                case "Countrydescend":
                    companies = companies.OrderByDescending(c => c.Country);
                    break;
                case "NumberofUsersdescend":
                    companies = companies.OrderByDescending(c => c.Users.Count());
                    break;
                default:
                    break;
            }
            PaginationResponse<Company> response = new PaginationResponse<Company>();
            response.ResponseList = companies.
                Skip(Math.Max((request.PageNumber - 1) * request.PageSize,0)).
                Take(request.PageSize).
                ToList();
            response.Count = _context.Companies.Count();
            return response;
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
