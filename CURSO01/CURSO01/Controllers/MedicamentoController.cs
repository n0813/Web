using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CURSO01.Clases;
using CURSO01.Models;
using Microsoft.AspNetCore.Mvc;

namespace CURSO01.Controllers
{
    public class MedicamentoController : Controller
    {
        public IActionResult Index()
        {
            List<MedicamentoCSL> listaMedicamento = new List<MedicamentoCSL>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                listaMedicamento = (from medic in db.Medicamento
                                   join farmace in db.FormaFarmaceutica on medic.Iidformafarmaceutica equals farmace.Iidformafarmaceutica
                                   select new MedicamentoCSL
                                   {
                                       iidmedicamento = medic.Iidmedicamento,
                                       nombre = medic.Nombre,
                                       precio = (decimal) medic.Precio,
                                       stock = (int) medic.Stock,
                                       nombreFarmaceutica = farmace.Nombre
                                   }).ToList();

            }

            return View(listaMedicamento);
        } 
    }
}
