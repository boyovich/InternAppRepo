using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternApp.Domain.Entities
{
    public class Company
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public User[] Users { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
