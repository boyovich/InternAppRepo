using InternApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
