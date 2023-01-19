using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class PacienteController: Controller
    {
        private readonly TurnosContext _context;
        public PacienteController(TurnosContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View (await _context.Paciente.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var paciente = await _context.Paciente.FirstOrDefaultAsync(p => p.IdPaciente == id);
            if(paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }
        public IActionResult CreatePaciente()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //validacion para asegurar que la informacion sea ingresada por el formulario en la vista del usurio. Evitamos ataque de inyeccion por medio de la direcion web
        public async Task<IActionResult>CreatePaciente([Bind("IdPaciente, Nombre, Apellido, Direccion, Telefono,Email")] Paciente paciente)
        {
            if(ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> EditPaciente(int? id)
        {
            if(id== null)
            {
                return NotFound();
            }
            var paciente = await _context.Paciente.FindAsync(id);
            if(paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPaciente(int id,[Bind("IdPaciente,Nombre, Apellido, Direccion, Telefono, Email")] Paciente paciente)
        {
            if( id!= paciente.IdPaciente)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
            _context.Update(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }
        

    }
}