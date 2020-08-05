﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CURSO01.Clases;
using CURSO01.Models;
using Microsoft.AspNetCore.Mvc;

namespace CURSO01.Controllers
{
    public class SedeController : Controller
    {
        public IActionResult Index(SedeCLS oSedeCLS)
        {

            List<SedeCLS> listaSede = new List<SedeCLS>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                if (oSedeCLS.nombreSede == null || oSedeCLS.nombreSede == "")
                {

                    listaSede = (from sede in db.Sede
                                 where sede.Bhabilitado == 1
                                 select new SedeCLS
                                 {
                                     iidSede = sede.Iidsede,
                                     nombreSede = sede.Nombre,
                                     direccion = sede.Direccion
                                 }).ToList();

                    ViewBag.nombreSede = "";
                }
                else
                {

                    listaSede = (from sede in db.Sede
                                 where sede.Bhabilitado == 1
                                 && sede.Nombre.Contains(oSedeCLS.nombreSede)
                                 select new SedeCLS
                                 {
                                     iidSede = sede.Iidsede,
                                     nombreSede = sede.Nombre,
                                     direccion = sede.Direccion
                                 }).ToList();

                    ViewBag.nombreSede = oSedeCLS.nombreSede;
                }

            }

            return View(listaSede);
        }
    }
}
