using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CURSO01.Clases;
using CURSO01.Models;
using Microsoft.AspNetCore.Mvc;

namespace CURSO01.Controllers
{
    public class EspecialidadController : Controller
    {
        public IActionResult Index(EspecialidadCLS oEspecialidad)
        {
            List<EspecialidadCLS> listaEspecialidad = new List<EspecialidadCLS>();

            using (BDHospitalContext db = new BDHospitalContext())
            {

                if (oEspecialidad.nombre == null || oEspecialidad.nombre == "")
                {
                    listaEspecialidad = (from x in db.Especialidad
                                         where x.Bhabilitado == 1
                                         select new EspecialidadCLS
                                         {
                                             iidespeciadlidad = x.Iidespecialidad,
                                             nombre = x.Nombre,
                                             descripcion = x.Descripcion
                                         }).ToList();

                    ViewBag.nombreEspecialidad = "";
                }
                else
                {
                    listaEspecialidad = (from x in db.Especialidad
                                         where x.Bhabilitado == 1 &&
                                         x.Nombre.Contains(oEspecialidad.nombre)
                                         select new EspecialidadCLS
                                         {
                                             iidespeciadlidad = x.Iidespecialidad,
                                             nombre = x.Nombre,
                                             descripcion = x.Descripcion
                                         }).ToList();

                    ViewBag.nombreEspecialidad = oEspecialidad.nombre;
                }
            }

            return View(listaEspecialidad);
        }


        public IActionResult Agregar()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Especialidad oEspecialidad)
        {
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    if (!ModelState.IsValid)
                    {
                        return View(oEspecialidad);
                    }
                    else
                    {
                        Especialidad especialObj = new Especialidad();
                        especialObj.Nombre = oEspecialidad.Nombre;
                        especialObj.Descripcion = oEspecialidad.Descripcion;
                        especialObj.Bhabilitado = 1;
                        db.Especialidad.Add(especialObj);
                        db.SaveChanges();
                    }


                }
            }
            catch (Exception)
            {

                return View(oEspecialidad);  
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int iidespecialidad)
        {
            string error;
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    Especialidad oEspecialidad = db.Especialidad.Where(
                        x => x.Iidespecialidad == iidespecialidad).First();
                    oEspecialidad.Bhabilitado = 0;
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                error = ex.Message;
                
            }
            return RedirectToAction("Index");
        }


    }
}
