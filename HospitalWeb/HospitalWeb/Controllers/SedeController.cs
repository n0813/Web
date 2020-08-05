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
    public class SedeController : Controller
    {
        // GET: SedeController
        public ActionResult Index(SedeCLS oSedeCSL)
        {
            List<SedeCLS> listaSede = new List<SedeCLS>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                if (oSedeCSL.nombreSede == null || oSedeCSL.nombreSede == "")
                {
                    listaSede = (from x in db.Sede
                                 where x.Bhabilitado == 1
                                 select new SedeCLS
                                 {
                                     iidSede = x.Iidsede,
                                     nombreSede = x.Nombre,
                                     direccion = x.Direccion

                                 }).ToList();
                    ViewBag.Filtro = "";

                }
                else
                {
                    listaSede = (from x in db.Sede
                                 where x.Bhabilitado == 1
                                 && x.Nombre.Contains(oSedeCSL.nombreSede)
                                 select new SedeCLS
                                 {
                                     iidSede = x.Iidsede,
                                     nombreSede = x.Nombre,
                                     direccion = x.Direccion

                                 }).ToList();

                    ViewBag.Filtro = oSedeCSL.nombreSede;
                }
                

            }

            return View(listaSede);
        }

        // GET: SedeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SedeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SedeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SedeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SedeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SedeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SedeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
