using InternApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternApp.Domain.Persistance
{
    public class InternDbContext : DbContext
    {
        public InternDbContext(DbContextOptions<InternDbContext> options) : base(options)
        {

        }

        DbSet<User> users { get; set; }

        DbSet<Company> companies { get; set; }


    }
}
