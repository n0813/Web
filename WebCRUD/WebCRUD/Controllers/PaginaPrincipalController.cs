using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCRUD.Models;

namespace WebCRUD.Controllers
{
    public class PaginaPrincipalController : Controller
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
                //string clavecifrada = 
                int nveces = db.Usuario.Where(x => x.Nombreusuario == user
                && x.Contraseña == pass).Count();

                if (nveces != 0)
                {
                    rpta = "OK";
                }


            }return rpta;
            
        }
    }
}
