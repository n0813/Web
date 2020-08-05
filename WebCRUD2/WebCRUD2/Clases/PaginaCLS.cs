using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCRUD2.Clases
{
    public class PaginaCLS
    {
		[Display(Name = "Id Pagina")]
		public int iidPagina { get; set; }
		[Display(Name = "Mensaje")]
		[Required(ErrorMessage = "Debe ingresar mensaje")]
		public string mensaje { get; set; }
		[Display(Name = "Nombre de la Acciòn")]
		[Required(ErrorMessage = "Debe ingresar accion")]

		public string accion { get; set; }
		[Display(Name = "Nombre del Controlador")]
		[Required(ErrorMessage = "Debe ingresar controlador")]
		[MinLength(3, ErrorMessage = "La longitud minima es 3")]
		[MaxLength(100, ErrorMessage = "La longitud maxima es 50")]

		public string controlador { get; set; }

		public string mensajeError { get; set; }

	}
}
