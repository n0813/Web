using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCRUD.Models;

namespace WebCRUD.Controllers
{
    public class TipoUsuarioController : Controller
    {
        // GET: TipoUsuarioController1cs
        public ActionResult Index()
        {
            List<TipoUsuarioCLS> listaTipoUsuario = new List<TipoUsuarioCLS>();

            using (BDHospitalContext db = new BDHospitalContext())
            {
                
                listaTipoUsuario = (from x in db.TipoUsuario
                                    where x.Bhabilitado == 1
                                    select new TipoUsuarioCLS 
                                    {
                                        iidTipoUsuario = x.Iidtipousuario,
                                        nombre = x.Nombre,
                                        descripcion = x.Descripcion
                                    }).ToList();


            }

            return View(listaTipoUsuario);
        }

        //// GET: TipoUsuarioController1cs/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: TipoUsuarioController1cs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoUsuarioController1cs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoUsuarioCLS  oTipoUsuarioCLS)
        {
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    if (!ModelState.IsValid)
                    {
                        return View(oTipoUsuarioCLS);
                    }
                    else
                    {
                        TipoUsuario tipoUsuario = new TipoUsuario();
                        tipoUsuario.Bhabilitado = 1;
                        tipoUsuario.Nombre = oTipoUsuarioCLS.nombre;
                        tipoUsuario.Descripcion = oTipoUsuarioCLS.descripcion;
                        db.Add(tipoUsuario);
                        db.SaveChanges();

                    }

                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoUsuarioController1cs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoUsuarioController1cs/Edit/5
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

        //// GET: TipoUsuarioController1cs/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: TipoUsuarioController1cs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Iidtipousuario)
        {

            using (BDHospitalContext db = new BDHospitalContext())
            {
                TipoUsuario oTipoUsuario = db.TipoUsuario
                    .Where(x => x.Iidtipousuario == Iidtipousuario).First();
                //db.TipoUsuario.Remove(oTipoUsuario);
                oTipoUsuario.Bhabilitado = 0;
                db.SaveChanges();
            }
            return RedirectToAction("Index");


            //return RedirectToAction("Index");
        }
    }
}
