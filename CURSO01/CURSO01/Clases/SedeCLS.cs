using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CURSO01.Clases
{
    public class SedeCLS
    {
        [Display(Name ="ID")]
        public int iidSede { get; set; }
        [Display(Name ="Nombre")]
        public string  nombreSede { get; set; }
        [Display(Name ="Direccion")]
        public string direccion { get; set; }

    }
}
