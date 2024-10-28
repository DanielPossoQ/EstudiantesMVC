using Microsoft.AspNetCore.Mvc;
using EstudiantesMVC.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesMVC.Controllers
{
    public class MatriculasController : Controller
    {
        private readonly AppDbContext _context;

        public MatriculasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Matriculas
        public IActionResult Index()
        {
            var matriculas = _context.matriculas.ToList();
            return View(matriculas);
        }

        // GET: Matriculas/Create
        public IActionResult Create()
        {
            ViewBag.Estudiantes = _context.Estudiantes.ToList();
            ViewBag.Cursos = _context.cursos.ToList();
            return View();
        }

        // POST: Matriculas/Create
      [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _context.matriculas.Add(matricula);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            // Si hay un error, vuelve a llenar las listas
            ViewBag.Estudiantes = _context.Estudiantes.ToList();
            ViewBag.Cursos = _context.cursos.ToList();
            return View(matricula);
        }

        // Otros métodos para Editar y Eliminar...
              public IActionResult Edit(int id)
        {
            var matricula = _context.matriculas.Include(m => m.Estudiante).Include(m => m.Curso).FirstOrDefault(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound();
            }
            ViewBag.Estudiantes = _context.Estudiantes.ToList();
            ViewBag.Cursos = _context.cursos.ToList();
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Matricula matricula)
        {
            if (id != matricula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(matricula);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Estudiantes = _context.Estudiantes.ToList();
            ViewBag.Cursos = _context.cursos.ToList();
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public IActionResult Delete(int id)
        {
            var matricula = _context.matriculas.Include(m => m.Estudiante).Include(m => m.Curso).FirstOrDefault(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound();
            }
            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var matricula = _context.matriculas.Find(id);
            if (matricula != null)
            {
                _context.matriculas.Remove(matricula);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}