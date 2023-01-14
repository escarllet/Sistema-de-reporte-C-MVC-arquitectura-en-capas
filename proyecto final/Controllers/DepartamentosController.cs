using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using CapaEntidad;
using System.Net;

namespace proyecto_final.Controllers
{
    public class DepartamentosController : Controller
    {
     

        // GET: Departamentos
        public ActionResult Departamentos()
        {
            if (misVariables.sioNo == 1)
            {
                
                var dep = DepartamentoN.ListaDepartamentos();
                return View(dep);
            }
            else
            {
                return RedirectToAction("login", "Usuario");
            }

        }

        public ActionResult CrearDep()
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
        [HttpPost]
        public ActionResult CrearDep(Departamentos departamentos)
        {
            try
            {
                if (departamentos.nombreDep == null|| departamentos.siglas == null)
                {
                    ModelState.AddModelError("", "ERROR: No se pueden dejar campos vacios");
                    return View(departamentos);
                }
                DepartamentoN.AgregarDep(departamentos);
                return RedirectToAction("Departamentos");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","ERROR EN AGREGAR DEPARTAMENTO: "+ex.Message);
                return View(departamentos);
            }
           
        }
        public ActionResult EditarDep(int id)
        {
            if (misVariables.sioNo == 1)
            {
                
                var dep = DepartamentoN.GetDepartamento(id);
                return View(dep);
            }
            else
            {
                return RedirectToAction("login", "Usuario");
            }

        }
        [HttpPost]
        public ActionResult EditarDep(Departamentos departamentos)
        {
            try
            {
                if (departamentos.nombreDep == null || departamentos.siglas == null)
                {
                    ModelState.AddModelError("", "ERROR: No se pueden dejar campos vacios");
                    return View(departamentos);
                }
                DepartamentoN.editarDep(departamentos);
                return RedirectToAction("Departamentos");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "ERROR AL ACTUALIZAR EL DEPARTAMENTO: " + ex.Message);
                return View(departamentos);
            }
        }
      //  public ActionResult EliminarDep(int? id)
       // {
        //    if (id == null)
            
          //  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
           // var dep = DepartamentoN.GetDepartamento(id.Value);
           // return View(dep);
        //}
        [HttpPost]
        public ActionResult EliminarDep(int identificador)
        {
            try
            {

                DepartamentoN.EliminarDep(identificador);
                return Json(new {ok =true,toRedirect =Url.Action("Departamentos","Departamentos")},JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                
                return Json(new { ok = false, msg =ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult getDepartamento()
        {
            var lista = DepartamentoN.ListaDepartamentos();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}