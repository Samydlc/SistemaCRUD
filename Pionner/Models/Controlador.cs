using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Pionner.Models
{
    public class Controlador
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public String Modelo { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public String Software { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
         public int Canales { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public int Precio { get; set; }
        
        
    }
}
