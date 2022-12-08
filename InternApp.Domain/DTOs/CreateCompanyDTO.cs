using InternApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternApp.Domain.DTOs
{
    public class CreateCompanyDTO
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
