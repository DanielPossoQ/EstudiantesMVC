using System.ComponentModel.DataAnnotations;

namespace EstudiantesMVC.Models{

    public class Curso{
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCurso { get; set; }

        [Required]
        public int Creditos { get; set; }
    }
}