using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCRUD
{
    public class SedeCLS
    {
        [Display(Name = "Descripcion")]
        public int iidSede { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre no puede estar vacia")]
        public string  nombre { get; set; }
        
        [Display(Name = "direccion")]
        [Required(ErrorMessage = "La direccion no puede estar vacia")]
        public string direccion { get; set; }



    }
}
