using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternApp.Domain.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set;}
        public DateTime DOB { get; set; }
        public Position position { get; set; }
        public string PhoneNumber { get; set; }


    }
}
