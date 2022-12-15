using InternApp.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace InternApp.API
{
    public static class InitializeDb
    {
        public static void InitializeDatabase(IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<InternDbContext>().Database.Migrate();
            }
        }
    }
}
