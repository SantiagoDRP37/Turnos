using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente{get; set;}

        [Required(ErrorMessage ="Debe ingresar un nombre")]
        [Display(Name ="Nombre")]
        public string Nombre {get; set;}

        [Required(ErrorMessage ="Debe ingresar un apellido")]
        [Display(Name ="Apellido")]
        public string Apellido{get; set;}

        [Required(ErrorMessage ="Debe ingresar una dirección")]
        [Display(Name ="Dirección")]
         public string Direccion{get; set;}

        [Required(ErrorMessage ="Debe ingresar un telefono")]
        [Display(Name ="Teléfono")]
        public string Telefono{get; set;}

        [Required(ErrorMessage ="Debe ingresar un email")]
        [Display(Name ="Email")]
        public string Email{get; set;}
        
    }
}