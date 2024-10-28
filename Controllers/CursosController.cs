using Microsoft.AspNetCore.Mvc;
using EstudiantesMVC.Models;
using System.Linq;

namespace EstudiantesMVC.Controllers
{
    public class CursosController : Controller
    {
        private readonly AppDbContext _context;

        public CursosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Cursos
        public IActionResult Index()
        {
            var cursos = _context.cursos.ToList();
            return View(cursos);
        }

        // GET: Cursos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cursos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.cursos.Add(curso);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        // Otros métodos para Editar y Eliminar...
                public IActionResult Edit(int id)
        {
            var cursos = _context.cursos.Find(id);
            if (cursos == null)
            {
                return NotFound();
            }
            return View(cursos);
        }

        // POST: Estudiantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Curso curso)
        {
            if (id != curso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(curso);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        // GET: Estudiantes/Delete/5
        public IActionResult Delete(int id)
        {
            var cursos = _context.cursos.Find(id);
            if (cursos == null)
            {
                return NotFound();
            }
            return View(cursos);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cursos = _context.cursos.Find(id);
            if (cursos != null)
            {
                _context.cursos.Remove(cursos);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}