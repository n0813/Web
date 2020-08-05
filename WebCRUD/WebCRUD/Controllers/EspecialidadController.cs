using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using WebCRUD.Models;

namespace WebCRUD.Controllers
{
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
        public ActionResult Index(EspecialidadCLS oEspecialidad)
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
                                         where x.Bhabilitado == 1
                                         && x.Nombre.Contains(oEspecialidad.nombre)
                                         select new EspecialidadCLS
                                         {
                                             iidespeciadlidad = x.Iidespecialidad,
                                             nombre = x.Nombre,
                                             descripcion = x.Descripcion
                                         }).ToList();


                    ViewBag.nombreEspecialidad = oEspecialidad.nombre;
                }
            }
            lista = listaEspecialidad;
            return View(listaEspecialidad);
        }

        // GET: EspecialidadController/Details/5
        public ActionResult Detalle(int id)
        {
            return View();
        }

        // GET: EspecialidadController/Create
        public ActionResult Agregar()
        {
            return View();
        }

        // POST: EspecialidadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(EspecialidadCLS oEspecialidadCLS)
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
                        Especialidad especialObj = new Especialidad();
                        especialObj.Nombre = oEspecialidadCLS.nombre;
                        especialObj.Descripcion = oEspecialidadCLS.descripcion;
                        especialObj.Bhabilitado = 1;
                        db.Especialidad.Add(especialObj);
                        db.SaveChanges();
                    }

                }
            }
            catch
            {
                return View(oEspecialidadCLS);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EspecialidadController/Edit/5
        public ActionResult Modificar(int id)
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
        public ActionResult Modificar(int id, EspecialidadCLS oEspecialidadCLS)
        {
            try
            {
                
                using (BDHospitalContext db =new BDHospitalContext())
                {
                    if (!ModelState.IsValid)
                    {
                        return View(oEspecialidadCLS);
                    }
                    else
                    {
                        Especialidad oEspecialidad = new Especialidad();
                        oEspecialidad.Nombre = oEspecialidadCLS.nombre;
                        oEspecialidad.Descripcion = oEspecialidadCLS.descripcion;
                        oEspecialidad.Iidespecialidad = oEspecialidadCLS.iidespeciadlidad;
                        oEspecialidad.Bhabilitado = 1;
                        db.Update(oEspecialidad);
                        db.SaveChanges();
                    }
                    //oEspecialidad = 
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EspecialidadController/Delete/5
        //public ActionResult Eliminar(int id)
        //{
        //    return View();
        //}

        // POST: EspecialidadController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Eliminar(int iidespeciadlidad)
        {
            string error;
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    Especialidad oEspecialidad = db.Especialidad
                        .Where(x => x.Iidespecialidad == iidespeciadlidad).First();
                    db.Especialidad.Remove(oEspecialidad);
                    //oEspecialidad.Bhabilitado = 0;
                    db.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
