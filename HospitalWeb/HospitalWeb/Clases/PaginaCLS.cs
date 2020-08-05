using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWeb.Clases
{
    public class PaginaCLS
    {

        [Display(Name ="ID")]
        public int iiPagina { get; set; }
        [Display(Name ="Mensaje")]
        [Required(ErrorMessage ="Se debe ingresar el nombre del mensaje")]
        public string mensaje { get; set; }
        [Display(Name = "Accion")]
        [Required(ErrorMessage = "Se debe ingresar el nombre de la accion")]
        public string accion { get; set; }
        [Display(Name = "Controller")]
        [Required(ErrorMessage = "Se debe ingresar el nombre del controller")]
        public string controller { get; set; }


    }
}
