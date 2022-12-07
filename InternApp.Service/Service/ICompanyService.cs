using InternApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternApp.Service.Service
{
    public interface ICompanyService
    {
        public IEnumerable<Company> GetAllCompanies();
        public Company GetCompanyById(string id);
    }
}
