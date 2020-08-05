using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCRUD.Models;

namespace WebCRUD.Controllers
{
    public class SedeController : Controller
    {
        // GET: SedeController
        public ActionResult Index()
        {
            List<SedeCLS> listaSede = new List<SedeCLS>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                listaSede = (from x in db.Sede
                            where x.Bhabilitado == 1
                            select new SedeCLS
                            {
                                iidSede = x.Iidsede,
                                nombre = x.Nombre,
                                direccion = x.Direccion
                            }).ToList();

            }

            return View(listaSede);
        }

        // GET: SedeController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: SedeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SedeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SedeCLS oSedeCSL)
        {
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    if (!ModelState.IsValid)
                    {
                        return View(oSedeCSL);
                    }
                    else
                    {
                        Sede oSede = new Sede();
                        oSede.Nombre = oSedeCSL.nombre;
                        oSede.Direccion = oSedeCSL.direccion;
                        db.Add(oSede);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(oSedeCSL);
            }
        }

        // GET: SedeController/Edit/5
        public ActionResult Edit(int id)
        {
            SedeCLS oSedeCLS = new SedeCLS();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                oSedeCLS = (from x in db.Sede
                            where x.Iidsede == id
                            select new SedeCLS
                            {
                                iidSede = x.Iidsede,
                                nombre = x.Nombre,
                                direccion = x.Direccion

                            }).First();
            
                
            }

            return View(oSedeCLS);
        }

        // POST: SedeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SedeCLS oSedeCLS)
        {
            try
            {
                using (BDHospitalContext db =new BDHospitalContext())
                {
                    Sede oSede = new Sede();
                    oSede.Nombre = oSedeCLS.nombre;
                    oSede.Iidsede = oSedeCLS.iidSede;
                    oSede.Direccion = oSedeCLS.direccion;
                    oSede.Bhabilitado = 1;
                    db.Update(oSede);
                    db.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(oSedeCLS);
            }
        }

        //// GET: SedeController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: SedeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int iidSede)
        {
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    Sede oSede = db.Sede
                        .Where(x => x.Iidsede == iidSede).First();

                    oSede.Bhabilitado = 0;
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
