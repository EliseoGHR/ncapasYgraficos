using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrurebaaNCapas.AccesoADatos
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddDALDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("conn")));
            services.AddScoped<PersonaADAL>();

            return services;
        }
    } 
}
