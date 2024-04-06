using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrurebaaNCapas.AccesoADatos;
using System;

namespace PrurebaaNCapas.LogicaDeNegocio
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddBLDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDALDependecies(configuration);
            services.AddScoped<PersonaABL>();
            return services;
        }
    }
}
