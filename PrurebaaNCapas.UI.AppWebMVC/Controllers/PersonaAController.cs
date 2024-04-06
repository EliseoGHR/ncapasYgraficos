using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrurebaaNCapas.AccesoADatos;
using PrurebaaNCapas.EntidadesDeNegocio;
using PrurebaaNCapas.LogicaDeNegocio;

namespace PrurebaaNCapas.UI.AppWebMVC.Controllers
{
    public class PersonaAController : Controller
    {
        readonly PersonaABL _personaABL;
       
        public PersonaAController(PersonaABL personaABL)
        {
            _personaABL = personaABL;
        }
        // GET: PersonaAController
        public async Task<ActionResult> Index(PersonaA personaA)
        {
            var personasA = await _personaABL.Buscar(personaA);
            return View(personasA);
        }

        // GET: PersonaAController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var personasA = await _personaABL.ObtenerPorId(new PersonaA { Id = id });
            return View(personasA);
        }

        // GET: PersonaAController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonaAController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PersonaA personaA)
        {
            try
            {
                await _personaABL.Crear(personaA);
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaAController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var personasA = await _personaABL.ObtenerPorId(new PersonaA { Id = id });
            return View(personasA);
        }

        // POST: PersonaAController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PersonaA personaA)
        {
            try
            {
                await _personaABL.Modificar(personaA);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaAController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var personasA = await _personaABL.ObtenerPorId(new PersonaA { Id = id });
            return View(personasA);
        }

        // POST: PersonaAController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, PersonaA personaA)
        {
            try
            {
                await _personaABL.Eliminar(personaA);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult GraficoPorEdades()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> GetInfoGraficoPorEdades()
        {
            var persona = await _personaABL.ObtenerTodos();
            var yearActual = DateTime.Now.Year;
            //2024-18 = 2012
            // 2024-30 = 1994
            var personaEntre18y30 = persona.Where(s => s.FechaNacimiento.Year > (yearActual - 30) && s.FechaNacimiento.Year <= (yearActual - 18));
            var personaEntre31y50 = persona.Where(s => s.FechaNacimiento.Year > (yearActual - 50) && s.FechaNacimiento.Year <= (yearActual - 30));
            var personamayoresa50 = persona.Where(s => s.FechaNacimiento.Year > (yearActual - 200) && s.FechaNacimiento.Year <= (yearActual - 50));
            var objs = new List<object>();
            objs.Add(new
            {
                grupo = "Entre 18 y 30 años",
                cantidad = personaEntre18y30.Count(),
            });
            objs.Add(new
            {
                grupo = "Entre 30 y 50 años",
                cantidad = personaEntre31y50.Count(),
            });
            objs.Add(new
            {
                grupo = "Mayores a 50 años",
                cantidad = personamayoresa50.Count(),
            });
            return Json(objs);
        }

        public ActionResult GraficoPorNombres()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> GetInfoGraficoPorNombres()
        {
            var personas = await _personaABL.ObtenerTodos();
            var datosGrafico = personas
                .GroupBy(p => p.Nombre)
                .Select(g => new[] { g.Key, g.Count().ToString() })
                .OrderByDescending(x => int.Parse(x[1]))
                .Take(5)
                .ToList();

            return Json(datosGrafico);
        }
    }
}
