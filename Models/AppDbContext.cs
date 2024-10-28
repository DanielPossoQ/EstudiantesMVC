using Microsoft.EntityFrameworkCore;

namespace EstudiantesMVC.Models{

    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> cursos { get; set; }
        public DbSet<Matricula> matriculas { get; set; }
    }
}