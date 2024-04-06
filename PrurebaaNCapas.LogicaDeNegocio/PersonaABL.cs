using PrurebaaNCapas.AccesoADatos;
using PrurebaaNCapas.EntidadesDeNegocio;

namespace PrurebaaNCapas.LogicaDeNegocio
{
    public class PersonaABL
    {
        readonly PersonaADAL _personaADAL;

        public PersonaABL(PersonaADAL personaADAL)
        {
            _personaADAL = personaADAL;
        }
        public async Task<int> Crear(PersonaA personaA)
        {
            return await _personaADAL.Crear(personaA);
        }
        public async Task<int> Modificar(PersonaA personaA)
        {
            return await _personaADAL.Modificar(personaA);
        }
        public async Task<int> Eliminar(PersonaA personaA)
        {
            return await _personaADAL.Eliminar(personaA);
        }
        public async Task<PersonaA> ObtenerPorId(PersonaA personaA)
        {
            return await _personaADAL.ObtenerPorId(personaA);
        }
        public async Task<List<PersonaA>> ObtenerTodos()
        {
            return await _personaADAL.ObtenerTodos();
        }
        public async Task<List<PersonaA>> Buscar(PersonaA personaA)
        {
            return await _personaADAL.Buscar(personaA);
        }
    }
}
