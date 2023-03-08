using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }
        [Required (ErrorMessage ="Debe ingresar un nombre")]

        [Display (Name ="Nombre")]
        public string Nombre { get; set; }
        [Required (ErrorMessage ="Debe ingresar un apellido")]
        [Display (Name ="Apellido")]
        public string Apellido { get; set; }
        [Required (ErrorMessage ="Debe ingresar una direccion")]
        [Display (Name ="Dirección")]
        public string Direccion { get; set; }
        [Required (ErrorMessage ="Debe ingresar un telefono")]
        [Display (Name ="Teléfono")]
        public string Telefono { get; set; }
        [Required (ErrorMessage ="Debe ingresar un email")]
        [Display (Name ="Email")]
        [EmailAddress(ErrorMessage ="No es una dirección de email válida")]
        public string Email { get; set; }
        [Display(Name ="Horario desde")]
        public DateTime HorarioAtencionDesde { get; set; }
        [Display(Name ="Horario hasta")]
        public DateTime HorarioAtencionHasta { get; set; }

        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
}