using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWeb.Clases
{
    public class SedeCLS
    {

        [Display(Name ="ID")]
        public int iidSede { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage ="Debe ingresar el nombre de la sede")]
        public string nombreSede { get; set; }
        [Display(Name = "Nombre")] 
        [Required(ErrorMessage ="Debe ingresar la direccion")]
        public string direccion { get; set; }


    }
}
