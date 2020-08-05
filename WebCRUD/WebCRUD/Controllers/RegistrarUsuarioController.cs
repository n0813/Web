using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebCRUD.Controllers
{
    public class RegistrarUsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
