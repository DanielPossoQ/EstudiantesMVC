using System.ComponentModel.DataAnnotations;

namespace EstudiantesMVC.Models{
    public class Matricula{
        public int Id { get; set; }
        
        [Required]
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }

        [Required]
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}