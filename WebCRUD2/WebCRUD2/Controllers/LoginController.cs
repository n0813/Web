using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCRUD2.Clases;
using WebCRUD2.Models;

namespace WebCRUD2.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string login(string user, string pass)
        {
            string rpta = "";
            using (BDHospitalContext db = new BDHospitalContext())
            {
                int nveces = db.Usuario.Where(x => x.Nombreusuario == user &&
                x.Contraseña == pass).Count();

                if (nveces != 0)
                {
                    rpta = "OK";

                    Usuario usu = db.Usuario.Where(x => x.Nombreusuario == user &&
                                  x.Contraseña == pass).First();

                    //guardar cookies
                    HttpContext.Session.SetString("usuario", usu.Iidpersona.ToString());

                    int idTipo = usu.Iidtipousuario;
                    Generic.tipoUsuario = "Admin";

                    List<PaginaCLS> lista = (from x in db.TipoUsuarioPagina
                                             join pagina in db.Pagina 
                                             on x.Iidpagina equals pagina.Iidpagina
                                             where x.Bhabilitado == 1 &&
                                             x.Iidtipousuario == idTipo
                                             select new PaginaCLS
                                             {
                                                 mensaje= pagina.Mensaje,
                                                 controlador = pagina.Controlador,
                                                 accion = pagina.Accion

                                             }).ToList();


                    //recorro para agregarlos
                    foreach (PaginaCLS item in lista)
                    {
                        Generic.listaMensaje.Add(item.mensaje);
                        Generic.listaController.Add(item.controlador);
                        Generic.listaAccion.Add(item.accion);
                    }


                }

            }
            return rpta;

        }

        public ActionResult Cerrar()
        {
            HttpContext.Session.Remove("usuario");
            return RedirectToAction("Index");
        }


    }
}
