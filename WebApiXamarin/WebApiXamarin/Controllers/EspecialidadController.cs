using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiXamarin.Clases;
using WebApiXamarin.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiXamarin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        // GET: api/<EspecialidadController>
        [HttpGet]
        public IEnumerable<EspecialidadCLS> Get()
        {
            List<EspecialidadCLS> listaEspecialidad = new List<EspecialidadCLS>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                listaEspecialidad = (from x in db.Especialidad
                                     where x.Bhabilitado == 1
                                     select new EspecialidadCLS
                                     {
                                         iidEspecialidad = x.Iidespecialidad,
                                         nombre = x.Nombre,
                                         Descripcion = x.Descripcion

                                     }).ToList();
            }
            //lista = listaEspecialidad;
            //return View(listaEspecialidad);

            return listaEspecialidad.ToList(); // .ToListAsync();

            //return new string[] { "value1", "value2" };
        }

        // GET api/<EspecialidadController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EspecialidadController>
        [HttpPost]
        public IActionResult Post([FromBody] EspecialidadCLS oEspecialidadCLS)
        {
            try
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    //si no es valido
                    if (!ModelState.IsValid)
                    { return BadRequest(); }
                    else
                    {
                        Especialidad especialidadOBJ = new Especialidad();
                        especialidadOBJ.Bhabilitado = 1;
                        especialidadOBJ.Nombre = oEspecialidadCLS.nombre;
                        especialidadOBJ.Descripcion = oEspecialidadCLS.Descripcion;
                        //especialidadOBJ.Iidespecialidad = oEspecialidadCLS.iidespeciadlidad;
                        db.Especialidad.Add(especialidadOBJ);
                        db.SaveChanges();
                    }

                }

                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT api/<EspecialidadController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EspecialidadController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
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
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
