using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWeb.Clases
{
    public class MedicamentoCSL
    {

        [Display(Name =("ID"))]
        public int? iidMedicamento { get; set; }

        [Display(Name ="Nombre")]
        [Required(ErrorMessage ="El nombre no puede estar vacio")]
        public string nombre { get; set; }
        [Display(Name = "Precio")]
        [Range(0,1000, ErrorMessage = "Debe estar en el rango de 0 a 1000")]
        public decimal? precio { get; set; }

        public string nombreFormaFarmaceutica { get; set; }
        [Display(Name = "Stock")]
        [Range(0, 1000, ErrorMessage = "Debe estar en el rango de 0 a 1000")]
        //[Required(ErrorMessage = "El stock no puede estar vacio")]
        public int? stock { get; set; }

        [Display(Name = "Seleccione forma Farmaceutica")]
        [Required(ErrorMessage = "Ingrese la forma farmaceutica")]
        public int? iidFormaFarmaceutica { get; set; }

        [Display(Name = "Concentracion")]
        [Required(ErrorMessage = "Ingrese la concentracion")]
        public string concentracion { get; set; }

        [Display(Name = "Presentacion")] 
        [DataType(DataType.MultilineText)]
        public string presentacion { get; set; }

    }
}
