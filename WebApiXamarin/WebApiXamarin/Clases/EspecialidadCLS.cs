using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiXamarin.Clases
{
    public class EspecialidadCLS
    {

        [Key]
        public int iidEspecialidad { get; set; }

        public string nombre { get; set; }

        public string Descripcion { get; set; }

    }
}
