using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CURSO01.Clases;
using CURSO01.Models;
using Microsoft.AspNetCore.Mvc;

namespace CURSO01.Controllers
{
    public class PaginaController : Controller
    {
        public IActionResult Index()
        {

            List<PaginaCLS> listaPagina = new List<PaginaCLS>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                listaPagina = (from x in db.Pagina
                              where x.Bhabilitado == 1
                              select new PaginaCLS
                              {
                                  iidPagina = x.Iidpagina,
                                  mensaje = x.Mensaje,
                                  accion = x.Accion,
                                  controlador = x.Controlador
                              }).ToList();
            }

            return View(listaPagina);
        }

        public IActionResult Agregar()
        {
            return View();
        }

            [HttpPost]
        public IActionResult Agregar(PaginaCLS oPagina)
        {
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    if (!ModelState.IsValid)
                    {
                        return View(oPagina);
                    }
                    else
                    {
                        Pagina pag = new Pagina();
                        pag.Mensaje = oPagina.mensaje;
                        pag.Controlador = oPagina.controlador;
                        pag.Accion = oPagina.accion;
                        pag.Bhabilitado = 1;
                        db.Pagina.Add(pag);
                        db.SaveChanges();
                    }

                }
            }
            catch (Exception)
            {
                return View(oPagina);
            }

            return RedirectToAction("Index");
        }
    }
}
