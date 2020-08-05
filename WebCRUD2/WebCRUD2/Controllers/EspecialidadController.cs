using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using WebCRUD2.Clases;
using WebCRUD2.Filters;
using WebCRUD2.Models;

namespace WebCRUD2.Controllers
{
    [ServiceFilter(typeof(Seguridad))]
    public class EspecialidadController : Controller
    {

        #region Excel

        //genera excel de array bytes
        public byte[] exportarExcelDatos<T>(string[] cabeceras, string[] nombrePropiedades, List<T> lista_excel)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage ep = new ExcelPackage())
                {
                    ep.Workbook.Worksheets.Add("Hoja");
                    ExcelWorksheet ew = ep.Workbook.Worksheets[0];

                    //empieza recorrido
                    for (int i = 0; i < cabeceras.Length; i++)
                    {
                        ew.Cells[1, i + 1].Value = cabeceras[i];
                        ew.Column(i + 1).Width = 50;

                    }

                    int fila = 2, col = 1;
                    foreach (object item in lista_excel)
                    {
                        col = 1;
                        foreach (string propiedades in nombrePropiedades)
                        {
                            ew.Cells[fila, col].Value =
                                item.GetType().GetProperty(propiedades).GetValue(item).ToString();

                            col++;
                        }
                        fila += 1;

                    }
                    ep.SaveAs(ms);

                    byte[] buffer = ms.ToArray();

                    return buffer;
                }

            }

        }

        public static List<EspecialidadCLS> lista;
        //descargar archivo de excel
        public FileResult exportarExcel()
        {
            string[] cabeceras = { "ID Especialidad", "Nombre", "Descripcion" };
            string[] nombrePropiedades = { "iidespeciadlidad", "nombre", "descripcion" };

            byte[] buffer = exportarExcelDatos(cabeceras, nombrePropiedades, lista);

            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

        }

        #endregion


        // GET: EspecialidadController
        
        public ActionResult Index()
        {
            List<EspecialidadCLS> listaEspecialidad = new List<EspecialidadCLS>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                listaEspecialidad = (from x in db.Especialidad
                                     where x.Bhabilitado == 1
                                     select new EspecialidadCLS
                                     {
                                         iidespeciadlidad = x.Iidespecialidad,
                                         nombre = x.Nombre,
                                         descripcion = x.Descripcion

                                     }).ToList();
            }
            lista = listaEspecialidad;
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
                    //si no es valido
                    if (!ModelState.IsValid)
                    { return View(oEspecialidadCLS); }
                    else
                    {
                        Especialidad especialidadOBJ = new Especialidad();
                        especialidadOBJ.Bhabilitado = 1;
                        especialidadOBJ.Nombre = oEspecialidadCLS.nombre;
                        especialidadOBJ.Descripcion = oEspecialidadCLS.descripcion;
                        //especialidadOBJ.Iidespecialidad = oEspecialidadCLS.iidespeciadlidad;
                        db.Especialidad.Add(especialidadOBJ);
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
            using (BDHospitalContext db =new BDHospitalContext())
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
        public ActionResult Edit(int id,  EspecialidadCLS oEspecialidadCLS)
        {
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    if (!ModelState.IsValid)
                    { return View(oEspecialidadCLS); }
                    else
                    {
                        Especialidad especialObj = new Especialidad();
                        especialObj.Nombre = oEspecialidadCLS.nombre;
                        especialObj.Descripcion = oEspecialidadCLS.descripcion;
                        especialObj.Bhabilitado = 1;
                        especialObj.Iidespecialidad = oEspecialidadCLS.iidespeciadlidad;
                        db.Especialidad.Update(especialObj);
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

        //// GET: EspecialidadController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: EspecialidadController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            string error;
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    Especialidad oEspecialidad = db.Especialidad
                        .Where(x => x.Iidespecialidad == id).First();
                    oEspecialidad.Bhabilitado = 0;
                    db.SaveChanges();

                }

                
            }
            catch(Exception ex)
            {
                error = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
