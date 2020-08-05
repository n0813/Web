# Web

Sitios Web y WebApi<br>

//agrega conexion a base de datos<br>

scaffold-DBContext "server=DESKTOP-922605J;database=BDHospital;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -Output Models<br>


//actualizar base de datos<br>

scaffold-DBContext "server=DESKTOP-922605J;database=BDHospital;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -Output Models -force<br>

//---------------------------------Complementos--------------------------------------------------//<br>

//reportes, nuget para reportes en word, excel y pdf<br>
  epplus
  
//sweet alert 2 <br>
//para pop up <br>
https://sweetalert2.github.io/<br>

//Iconos para web<br>
https://fontawesome.bootstrapcheatsheets.com/<br>
  
//---------------------------------Login--------------------------------------------------//<br>

//crear controlador para login <br>
//crear vista con login y registrar <br>

//cookis<br>
Agregar " App.UseSession(); " en Startup en el apartado de App.UseAuthorizacion(); <br>

instalar session con nuget , buscar <br>
AspNetCore.Session , insta ar Microsoft.AspNetCore.Session <br>

en Startup agregar el servicio de la session en la parte de <br>
   public void ConfigureServices(IServiceCollection services) <br>
        {<br>
            services.AddControllersWithViews(); <br>
            services.AddSession(); // se agrego linea <br>
        } <br>


// Si se desea poner un controlador de pagina principal o home (nota crear vista) <br>
guardar cookies<br>
dentro de la consulta de validacion agregar <br>
HttpContext.Session.SetString("usuario","pasar id usuario");<br>

//cerrar session, crear ActionResult para el boton de cerrar session<br>
HttpContext.Session.Remove("usuario");<br>
y redireccionar <br>



