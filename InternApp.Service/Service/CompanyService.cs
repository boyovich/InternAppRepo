using InternApp.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternApp.Service.Service
{
    public class CompanyService : ICompanyService
    {
        public IEnumerable<Company> GetAllCompanies()
        {
            SqlConnection sqlConnection = 
        }

        public Company GetCompanyById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
