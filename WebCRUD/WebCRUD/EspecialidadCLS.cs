using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCRUD
{
    public class EspecialidadCLS
    {
        [Display(Name = "ID")]
        public int iidespeciadlidad { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre no puede estar vacio")]
        public string nombre { get; set; }
        
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "La descripcion no puede estar vacia")]
        public string descripcion { get; set; }

    }
}
