using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PrurebaaNCapas.AccesoADatos
{
    public class AppDBContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            const string conn = "Data Source=.;Initial Catalog=PruebaNCapasDB;Integrated Security=True;Encrypt=False";
            optionsBuilder.UseSqlServer(conn);

            return new AppDBContext(optionsBuilder.Options);
        }
    }
}
 