using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pionner.Models
{
    public class Archivos
    {
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public string Nombre { get; set; }
        [Display (Name ="Archivo Pdf")]
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public string pdf { get; set; }
        [Display(Name = "Cargar Imagen")]
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public string Imagen { get; set; }
    }
}
