using Microsoft.EntityFrameworkCore;
using PrurebaaNCapas.EntidadesDeNegocio;
using System;

namespace PrurebaaNCapas.AccesoADatos
{
    public class PersonaADAL
    {
        readonly AppDBContext _appDBContext;
        public PersonaADAL(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<int> Crear(PersonaA personaA)
        {
            _appDBContext.Add(personaA);
            return await _appDBContext.SaveChangesAsync();
        }
        public async Task<int> Modificar(PersonaA personaA)
        {
            var personaAData = await _appDBContext.PersonasA.FirstOrDefaultAsync(s => s.Id == personaA.Id);
            if (personaAData != null)
            {
                personaAData.Nombre = personaA.Nombre;
                personaAData.Direccion = personaA.Direccion;
                personaAData.FechaNacimiento = personaA.FechaNacimiento;
                personaAData.CorreoElectronico = personaA.CorreoElectronico;
                personaAData.Telefono = personaA.Telefono;
                _appDBContext.Update(personaAData);
            }
            return await _appDBContext.SaveChangesAsync();
        }
        public async Task<int> Eliminar(PersonaA personaA)
        {
            var personaAData = await _appDBContext.PersonasA.FirstOrDefaultAsync(s => s.Id == personaA.Id);
            if (personaAData != null)
                _appDBContext.Remove(personaAData);
            return await _appDBContext.SaveChangesAsync();
        }

        public async Task<PersonaA> ObtenerPorId(PersonaA personaA)
        {
            var personaAData = await _appDBContext.PersonasA.FirstOrDefaultAsync(s => s.Id == personaA.Id);
            if (personaAData != null)
                return personaAData;
            else
                return new PersonaA();
        }
        public async Task<List<PersonaA>> ObtenerTodos()
        {
            return await _appDBContext.PersonasA.ToListAsync();
        }
        public async Task<List<PersonaA>> Buscar(PersonaA personaA)
        {

            var query = _appDBContext.PersonasA.AsQueryable();
            if (!string.IsNullOrWhiteSpace(personaA.Nombre))
            {
                query = query.Where(s => s.Nombre.Contains(personaA.Nombre));
            }
            if (!string.IsNullOrWhiteSpace(personaA.CorreoElectronico))
            {
                query = query.Where(s => s.CorreoElectronico.Contains(personaA.CorreoElectronico));
            }
            if (personaA.Take == 0)
                personaA.Take = 10;
            query = query.Take(personaA.Take);
            return await query.ToListAsync();
        }
    }
}
