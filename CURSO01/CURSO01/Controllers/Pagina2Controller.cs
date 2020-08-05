using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CURSO01.Clases;
using CURSO01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CURSO01.Controllers
{
    public class Pagina2Controller : Controller
    {
        // GET: Pagina2Controller
        public ActionResult Index()
        {
            List<PaginaCLS> listaPagina = new List<PaginaCLS>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                listaPagina = (from x in db.Pagina
                              where x.Bhabilitado ==1
                              select new PaginaCLS
                              {
                                  iidPagina = x.Iidpagina,
                                  accion = x.Accion,
                                  controlador = x.Controlador,
                                  mensaje = x.Mensaje
                              }).ToList();
            }
            return View(listaPagina);
        }

        // GET: Pagina2Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pagina2Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pagina2Controller/Create
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

        // GET: Pagina2Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pagina2Controller/Edit/5
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

        // GET: Pagina2Controller/Delete/5
        public ActionResult Delete(int oPagin)
        {
            return View();
        }

        // POST: Pagina2Controller/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,PaginaCLS oPagina8)
        {
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    Pagina oPagina = db.Pagina
                        .Where(x => x.Iidpagina == id).First();
                    oPagina.Bhabilitado = 0;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}


