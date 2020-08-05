using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebCRUD2.Clases
{
    public class Generic
    {
		public static string cifrarDatos(string data)
		{
			SHA256Managed sha = new SHA256Managed();
			byte[] dataSinCifrar = Encoding.Default.GetBytes(data);
			byte[] dataCifrada = sha.ComputeHash(dataSinCifrar);

			return BitConverter.ToString(dataCifrada).Replace("-", "");
		}


		public static string tipoUsuario { get; set; }

		public static List<string> listaController { get; set; } = new List<string>();
		public static List<string> listaMensaje { get; set; } = new List<string>();
		public static List<string> listaAccion { get; set; } = new List<string>();


	}
}
