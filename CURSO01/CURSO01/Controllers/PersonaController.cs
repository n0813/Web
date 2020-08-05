using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CURSO01.Clases;
using CURSO01.Models;
using Microsoft.AspNetCore.Mvc;

namespace CURSO01.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            List<PersonaCLS> listaPersonas = new List<PersonaCLS>();

            using (BDHospitalContext db = new BDHospitalContext())
            {
                listaPersonas = (from persona in db.Persona
                                 join sexo2 in db.Sexo on persona.Iidsexo equals sexo2.Iidsexo
                                 where persona.Bhabilitado == 1
                                 select new PersonaCLS
                                 {
                                     iidpersona = persona.Iidpersona,
                                     nombreCompleto = persona.Nombre + " " + persona.Appaterno + " " +
                                     persona.Apmaterno,
                                     email = persona.Email,
                                     nombreSexo = sexo2.Nombre

                                 }).ToList();
            }

            return View(listaPersonas);
        }
    }
}
