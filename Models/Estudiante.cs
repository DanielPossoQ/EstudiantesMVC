using System.ComponentModel.DataAnnotations;


namespace EstudiantesMVC.Models{

    public class Estudiante{
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}