using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalWeb.Clases;
using HospitalWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWeb.Controllers
{
    public class EspecialidadController : Controller
    {
        // GET: EspecialidadController
        public ActionResult Index(EspecialidadCLS oEspecialidadCLS)
        {
            List<EspecialidadCLS> listaEspecialidad = new List<EspecialidadCLS>();

            using (BDHospitalContext db = new BDHospitalContext())
            {

                if (oEspecialidadCLS.nombre == null || oEspecialidadCLS.nombre == "")
                {
                    listaEspecialidad = (from x in db.Especialidad
                                         where x.Bhabilitado == 1
                                         select new EspecialidadCLS
                                         {
                                             iidespeciadlidad = x.Iidespecialidad,
                                             nombre = x.Nombre,
                                             descripcion = x.Descripcion

                                         }).ToList();
                    ViewBag.Filtro = "";
                }
                else
                {
                    listaEspecialidad = (from x in db.Especialidad
                                         where x.Bhabilitado == 1 &&
                                         x.Nombre.Contains(oEspecialidadCLS.nombre)
                                         select new EspecialidadCLS
                                         {
                                             iidespeciadlidad = x.Iidespecialidad,
                                             nombre = x.Nombre,
                                             descripcion = x.Descripcion

                                         }).ToList();

                    ViewBag.Filtro = oEspecialidadCLS.nombre;
                }

                

            }

            return View(listaEspecialidad);
        }



        //// GET: EspecialidadController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: EspecialidadController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EspecialidadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EspecialidadCLS oEspecialidadCLS)
        {
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    if (!ModelState.IsValid)
                    {
                        return View(oEspecialidadCLS);
                    }
                    else
                    {
                        Especialidad oEspecialidad = new Especialidad();
                        oEspecialidad.Bhabilitado = 1;
                        oEspecialidad.Nombre = oEspecialidadCLS.nombre;
                        oEspecialidad.Descripcion = oEspecialidadCLS.descripcion;
                        db.Especialidad.Add(oEspecialidad);
                        db.SaveChanges();
                    }

                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(oEspecialidadCLS);
            }
        }

        // GET: EspecialidadController/Edit/5
        public ActionResult Edit(int id)
        {

            EspecialidadCLS oEspecialidadCLS = new EspecialidadCLS();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                oEspecialidadCLS = (from x in db.Especialidad
                                    where x.Iidespecialidad == id
                                    select new EspecialidadCLS
                                    {
                                        iidespeciadlidad = x.Iidespecialidad,
                                        nombre = x.Nombre,
                                        descripcion = x.Descripcion
                                    }).First();

            }

            return View(oEspecialidadCLS);
        }

        // POST: EspecialidadController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EspecialidadCLS oEspecialidadCSL)
        {
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    if (!ModelState.IsValid)
                    { return View(oEspecialidadCSL); }
                    else
                    {
                        Especialidad objEspecial = new Especialidad();
                        objEspecial.Nombre = oEspecialidadCSL.nombre;
                        objEspecial.Descripcion = oEspecialidadCSL.descripcion;
                        objEspecial.Iidespecialidad = oEspecialidadCSL.iidespeciadlidad;
                        objEspecial.Bhabilitado = 1;
                        db.Especialidad.Update(objEspecial);
                        db.SaveChanges();
                    }

                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(oEspecialidadCSL);
            }
        }

        // GET: EspecialidadController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: EspecialidadController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id) //, IFormCollection collection)
        {
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    Especialidad oEspecialidad = db.Especialidad
                                                 .Where(x => x.Iidespecialidad == id).First();

                    //Eliminar fisica
                    //db.Remove(oEspecialidad);
                    //Eliminacion logica
                    oEspecialidad.Bhabilitado = 0;
                    db.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
