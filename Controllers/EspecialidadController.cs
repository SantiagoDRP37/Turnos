using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Turnos.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Turnos.Controllers
{
    public class EspecialidadController : Controller //herencia de clase controlador del framework asp.netcore.mvc
    {
        private readonly TurnosContext _context;
        public EspecialidadController (TurnosContext context)       //constructor en la clase
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Especialidad.ToListAsync());
        }

        public async  Task<IActionResult> Edit (int? id) // metodo edit que visualiza los cambios 
        {
            if (id== null){
                return NotFound();
            }
            var especialidad =await _context.Especialidad.FindAsync(id);
            
            if(especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }
        [HttpPost] // Esto diferencia el metodo Edit que graba, del edit de vista
        public async Task<IActionResult> Edit(int id,[Bind("IdEspecialidad,Descripcion")] Especialidad especialidad) 
        {
            if (id != especialidad.IdEspecialidad)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _context.Update(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); //redirige a la vista general a listado especialidad
            }
            return View(especialidad);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var especialidad =await _context.Especialidad.FirstOrDefaultAsync(e => e.IdEspecialidad == id);
            
            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var especialidad = await _context.Especialidad.FindAsync(id);
            _context.Especialidad.Remove(especialidad);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}