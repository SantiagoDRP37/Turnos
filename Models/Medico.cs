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
        public string Nombre { get; set; }
        [Required (ErrorMessage ="Debe ingresar un apellido")]
        public string Apellido { get; set; }
        [Required (ErrorMessage ="Debe ingresar una direccion")]
        public string Direccion { get; set; }
        [Required (ErrorMessage ="Debe ingresar un telefono")]
        public string Telefono { get; set; }
        [Required (ErrorMessage ="Debe ingresar un email")]
        public string Email { get; set; }
        public DateTime HorarioAtencionDesde { get; set; }
        public DateTime HorarioAtencionHasta { get; set; }

        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
}