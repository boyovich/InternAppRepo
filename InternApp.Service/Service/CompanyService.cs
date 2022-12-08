using InternApp.Domain.DTOs;
using InternApp.Domain.Entities;
using InternApp.Domain.Persistance;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternApp.Service.Service
{
    public class CompanyService : ICompanyService
    {
        private InternDbContext _context;
        private static Random random = new Random();

        public CompanyService(InternDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _context.Companies.OrderBy(c => c.Name).ToList();
        }
        public Company CreateCompany(CreateCompanyDTO companyDTO)
        {
            Company company = new Company();
            company.Name = companyDTO.Name;
            company.City= companyDTO.City;
            company.Country = companyDTO.Country;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            company.Id = new string(Enumerable.Repeat(chars,20).Select(s => s[random.Next(chars.Length)]).ToArray());
            _context.Companies.Add(company);
            _context.SaveChanges();
            return company;
        }
        public void DeleteCompany(string id)
        {
            _context.Remove(_context.Companies.Single(s => s.Id == id));
            _context.SaveChanges();
        }

        public Company UpdateCompany(string id, UpdateCompanyDTO companyDTO)
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
