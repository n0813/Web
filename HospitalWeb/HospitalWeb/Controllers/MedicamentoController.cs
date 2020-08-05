using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalWeb.Clases;
using HospitalWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalWeb.Controllers
{
    public class MedicamentoController : Controller
    {
        // GET: MedicamentoController
        public ActionResult Index()
        {
            List<MedicamentoCSL> listaMedicamento = new List<MedicamentoCSL>();

            using (BDHospitalContext db = new BDHospitalContext())
            {
                listaMedicamento = (from x in db.Medicamento
                                    join formaMedica in db.FormaFarmaceutica
                                    on x.Iidformafarmaceutica equals formaMedica.Iidformafarmaceutica
                               where x.Bhabilitado == 1
                               select new MedicamentoCSL
                               {
                                   iidMedicamento = x.Iidmedicamento,
                                   nombre = x.Nombre,
                                   nombreFormaFarmaceutica = formaMedica.Nombre,
                                   precio =(decimal) x.Precio,
                                   stock =(int) x.Stock
                               }).ToList();

            }

            return View(listaMedicamento);
        }

        //// GET: MedicamentoController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        public List<SelectListItem> listaFormaFarmaceutica()
        {
            List<SelectListItem> listaFormaFarmaceutica = new List<SelectListItem>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                listaFormaFarmaceutica = (from formafarma in db.FormaFarmaceutica
                                          where formafarma.Bhabilitado == 1
                                          select new SelectListItem
                                          {
                                              Text = formafarma.Nombre,
                                              Value = formafarma.Iidformafarmaceutica.ToString()
                                          }).ToList();
                listaFormaFarmaceutica.Insert(0, new SelectListItem
                {
                    Text = "--Seleccione--",
                    Value = ""
                });

            }

            return listaFormaFarmaceutica;
        }

        // GET: MedicamentoController/Create
        public ActionResult Create()
        {
            ViewBag.listaForma = listaFormaFarmaceutica();
            return View();
        }

        // POST: MedicamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicamentoCSL oMedicamentoCSLS)
        {
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    if (!ModelState.IsValid)
                    {
                        ViewBag.listaForma = listaFormaFarmaceutica();
                        return View(oMedicamentoCSLS);            
                    }
                    else
                    {
                        Medicamento objMedic = new Medicamento();
                        objMedic.Bhabilitado = 1;
                        objMedic.Nombre = oMedicamentoCSLS.nombre;
                        objMedic.Precio = oMedicamentoCSLS.precio;
                        objMedic.Stock = oMedicamentoCSLS.stock;
                        objMedic.Presentacion = oMedicamentoCSLS.presentacion;
                        objMedic.Concentracion = oMedicamentoCSLS.concentracion;
                        objMedic.Iidformafarmaceutica = oMedicamentoCSLS.iidFormaFarmaceutica;

                        db.Medicamento.Add(objMedic);
                        db.SaveChanges();


                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.listaForma = listaFormaFarmaceutica();
                return View(oMedicamentoCSLS);
            }
        }

        // GET: MedicamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            MedicamentoCSL oMedicamentoCLS = new MedicamentoCSL();

            using (BDHospitalContext db = new BDHospitalContext())
            {
                oMedicamentoCLS = (from x in db.Medicamento
                                   where x.Iidmedicamento ==id
                                   select new MedicamentoCSL
                                   {
                                       iidMedicamento = 1,
                                       nombre=x.Nombre,
                                       concentracion = x.Concentracion,
                                       precio = x.Precio,
                                       stock  = x.Stock,
                                       presentacion = x.Presentacion,
                                       iidFormaFarmaceutica = x.Iidformafarmaceutica
                                      
                                   }).First();

            }

            ViewBag.listaForma = listaFormaFarmaceutica();
            return View(oMedicamentoCLS);
        }

        // POST: MedicamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MedicamentoCSL oMedicamentoCLS)
        {
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    if (!ModelState.IsValid)
                    {
                        ViewBag.listaForma = listaFormaFarmaceutica();
                        return View(oMedicamentoCLS);
                    }
                    else
                    {
                        Medicamento oMedicamento = new Medicamento();
                        oMedicamento.Bhabilitado = 1;
                        oMedicamento.Concentracion = oMedicamentoCLS.concentracion;
                        oMedicamento.Stock = oMedicamentoCLS.stock;
                        oMedicamento.Presentacion = oMedicamentoCLS.presentacion;
                        oMedicamento.Precio = oMedicamentoCLS.precio;
                        oMedicamento.Nombre = oMedicamentoCLS.nombre;
                        oMedicamento.Iidmedicamento = id;
                        oMedicamento.Iidformafarmaceutica = oMedicamentoCLS.iidFormaFarmaceutica;
                        db.Medicamento.Update(oMedicamento);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.listaForma = listaFormaFarmaceutica();
                return View(oMedicamentoCLS);
            }
        }

        //// GET: MedicamentoController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: MedicamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    Medicamento oMedicamento = db.Medicamento
                        .Where(x => x.Iidmedicamento == id).First();
                    oMedicamento.Bhabilitado = 0;
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
