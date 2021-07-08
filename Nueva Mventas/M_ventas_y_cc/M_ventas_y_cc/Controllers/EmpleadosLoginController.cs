using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using M_ventas_y_cc.Models;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace M_ventas_y_cc.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmpleadosLoginController : ApiController
    {
        ApplicationDbContext DB = new ApplicationDbContext();
        [Route("Login")]
        [HttpPost]
        public IHttpActionResult employeeLogin(ENCARGADO login)
        {
            var log = DB.ENCARGADOS.Where(x => x.usuario.Equals(login.usuario) && x.contraseña.Equals(login.contraseña)).FirstOrDefault();

            if (log == null)
            {
                return Ok(new { status = 401, isSuccess = false, message = "Invalid User", });
            }
            else
                return Ok(new { status = 200, isSuccess = true, message = "User Login successfully", UserDetails = log });
        }
    }
}
