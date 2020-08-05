using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCRUD2.Filters
{
    public class Seguridad : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //capturar el usuario
            var usu = context.HttpContext.Session.GetString("usuario");
            if (usu == null)
            {
                context.Result = new RedirectToActionResult("Index", "Login",null);
                    //RedirectResult("Login");
            }

        }
    }
}
