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
    public class PersonaController : Controller
    {
        // GET: PersonaController
        public ActionResult Index()
        {
            List<PersonaCLS> listaPersona = new List<PersonaCLS>();

            using (BDHospitalContext db = new BDHospitalContext())
            {
                listaPersona = (from persona in db.Persona
                                join sexo in db.Sexo
                                on persona.Iidsexo equals sexo.Iidsexo
                                where persona.Bhabilitado == 1
                                select new PersonaCLS
                                {
                                    iidPersona = persona.Iidpersona,
                                    nombreCompleto = persona.Nombre + " " + persona.Appaterno 
                                        + " " + persona.Apmaterno,
                                    email = persona.Email,
                                    nombreSexo = sexo.Nombre

                                }).ToList();

            }

            return View(listaPersona);
        }

        //// GET: PersonaController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        public void llenarSexo()
        {
            //List<SelectLisItem>
            List<SelectListItem> listaSexo = new List<SelectListItem>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                listaSexo = (from sexo in db.Sexo
                             where sexo.Bhabilitado == 1
                             select new SelectListItem
                             {
                                 Text = sexo.Nombre,
                                 Value = sexo.Iidsexo.ToString()
                             }).ToList();
                listaSexo.Insert(0, new SelectListItem
                {
                    Text = "--Seleccione--",
                    Value = ""
                });
            }
            ViewBag.listaSexo = listaSexo;
        }


        // GET: PersonaController/Create
        public ActionResult Create()
        {
            llenarSexo();
            return View();
        }

        // POST: PersonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonaCLS oPersonaCLS)
        {
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    if (!ModelState.IsValid)
                    {
                        return View(oPersonaCLS);
                    }
                    else
                    {
                        Persona oPersona = new Persona();
                        oPersona.Nombre = oPersonaCLS.nombre;
                        oPersona.Email = oPersonaCLS.email;
                        oPersona.Iidsexo = oPersonaCLS.iidSexo;
                        oPersona.Fechanacimiento = oPersonaCLS.fechaNacimiento;
                        oPersona.Foto = oPersonaCLS.foto;
                        oPersona.Apmaterno = oPersonaCLS.apMaterno;
                        oPersona.Appaterno = oPersonaCLS.apPaterno;
                        oPersona.Bhabilitado = 1;
                        oPersona.Bpaciente = 0;
                        oPersona.Bdoctor = 0;
                        oPersona.Btieneusuario = 0;
                        db.Persona.Add(oPersona);
                        db.SaveChanges();

                    }

                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(oPersonaCLS);
            }
        }

        // GET: PersonaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonaController/Edit/5
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

        // GET: PersonaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonaController/Delete/5
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
