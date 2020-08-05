using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CURSO01.Clases
{
    public class PaginaCLS
    {
        [Display(Name ="ID")]
        public int iidPagina { get; set; }
        [Display(Name = "Mensaje")] 
        public string mensaje { get; set; }
        [Display(Name = "Nombre")] 
        public string accion { get; set; }
        [Display(Name = "Controlador")] 
        public string controlador { get; set; }
    }
}
