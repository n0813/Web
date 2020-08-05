using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebCRUD2.Controllers
{
    public class PaginaPrincipalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
