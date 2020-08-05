using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCRUD
{
    public class TipoUsuarioCLS
    {
        [Display(Name ="ID")]
        public int iidTipoUsuario { get; set; }
        
        [Display(Name ="Tipo Usuario")]
        [Required(ErrorMessage ="El tipo de usuario no puede estar vacio")]
        public string  nombre { get; set; }

        [Display(Name ="Descripcion")]
        [Required(ErrorMessage ="La descripcion no puede estar vacia")]
        public string descripcion { get; set; }

    }
}
