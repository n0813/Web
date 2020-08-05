using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWeb.Clases
{
    public class PersonaCLS
    {
		[Display(Name = "Id")]
		public int? iidPersona { get; set; }

        ////Añadiendo propiedades adicionales

        [Display(Name = "Ingrese nombre")]
        [Required(ErrorMessage = "Debe ingresar el nombre")]
        public string nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "Debe ingresar el apellido paterno")]

        public string apPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage = "Debe ingresar el apellido materno")]

        public string apMaterno { get; set; }

        //[Required(ErrorMessage = "Debe ingresar el numero telefonico")]
        //[MinLength(8, ErrorMessage = "Longitud minima 8 caracteres")]
        //[Display(Name = "Telefono Fijo")]
        //public string telefonoFijo { get; set; }
        //[Display(Name = "Telefono Celular")]

        //public string telefonoCelular { get; set; }

        [DataType(DataType.Date,
            ErrorMessage = "El formato de fecha no es correcto")]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Debe ingresar la fecha de nacimiento")]
        public DateTime? fechaNacimiento { get; set; }



        //[Display(Name = "Nombre Completo")]
		public string nombreCompleto { get; set; }
		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress, ErrorMessage = "El correo debe ser valido")]
		public string email { get; set; }
		//[Display(Name = "Nombre Sexo")]

		public string nombreSexo { get; set; }
        ////Añado una clase mas
        [Required(ErrorMessage = "Seleccione un Sexo")]
        [Display(Name = "Seleccione una opciòn")]
        public int? iidSexo { get; set; }

        //public string mensajeError { get; set; }
        //public string mensajeErrorCorreo { get; set; }

        //[Display(Name = "Fecha Nacimiento")]
        //public string fechaNacimientoCadena { get; set; }

        public string foto { get; set; }
    }
}
