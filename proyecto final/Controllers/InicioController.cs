using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using CapaEntidad;

namespace proyecto_final.Controllers
{
    public class InicioController : Controller
    {

        // GET: Inicio
        public ActionResult Index()
        {
            if (misVariables.sioNo == 1)
            {
                
                return View();
            }
            else
            {
                return RedirectToAction("login", "Usuario");
            }
            
        }

       
    }
}
