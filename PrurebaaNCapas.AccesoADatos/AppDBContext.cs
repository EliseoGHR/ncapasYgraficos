using Microsoft.EntityFrameworkCore;
using PrurebaaNCapas.EntidadesDeNegocio;
using System;

namespace PrurebaaNCapas.AccesoADatos
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<PersonaA> PersonasA { get; set; }
    }
}
