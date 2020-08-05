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
    public class PaginaController : Controller
    {
        // GET: PaginaController
        public ActionResult Index()
        {
            List<PaginaCLS> listaPagina = new List<PaginaCLS>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                listaPagina = (from x in db.Pagina
                               where x.Bhabilitado == 1
                               select new PaginaCLS
                               { 
                                    iiPagina = x.Iidpagina,
                                    mensaje = x.Mensaje,
                                    accion = x.Accion,
                                    controller = x.Controlador
                               }).ToList();

            }

            return View(listaPagina);
        }

        //// GET: PaginaController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: PaginaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaginaController/Create
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

        // GET: PaginaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaginaController/Edit/5
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

        // GET: PaginaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaginaController/Delete/5
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
