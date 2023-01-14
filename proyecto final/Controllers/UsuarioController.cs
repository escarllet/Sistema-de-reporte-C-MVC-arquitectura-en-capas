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
    public class UsuarioController : Controller
    {

        
        // GET: Usuario
        public ActionResult login()
        {
            misVariables.correo = "";
            misVariables.sioNo = 0;
            misVariables.id = 0;
            misVariables.nombreDEP = "";
            return View();
        }
        [HttpPost]
        public ActionResult login(Empleados empleados)
        {
            try
            {
                if (empleados.email != null || empleados.Pass != null)
                {
                    
                    if (UsuarioN.GetUsuario(empleados) >= 1)
                    {
                        misVariables.sioNo = 1;
                        misVariables.correo = empleados.email;
                        misVariables.id = UsuarioN.getIdporEmail(misVariables.correo);
                        misVariables.nombreDEP = UsuarioN.ElDepartamento(misVariables.correo);
                        return RedirectToAction("Index", "Inicio");
                    }
                    else
                    {
                        ModelState.AddModelError("", "ERROR: Usuario no existe");
                        return View(empleados);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "INTRODUZCA EMAIL Y PASS");
                    return View(empleados);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "ERROR AL LOGUEAR: " + ex.Message);
                return View(empleados);
                throw;
            }
        }
        public ActionResult Perfil()
        {
            if (misVariables.sioNo == 1)
            {
                
                
                var dep = UsuarioN.GetUsuarioEmail(misVariables.id);
                return View(dep);
                
            }
            else
            {
                return RedirectToAction("login", "Usuario");
            }

        }
        [HttpPost]
        public ActionResult Perfil(Empleados empleados)
        { //arreglar klk
            try
            {
                if ( empleados.nombre ==null || empleados.apellido == null|| empleados.Pass == null|| empleados.email ==null)
                {
                    ModelState.AddModelError("", "ERROR: No se pueden dejar los siguientes campos vacios: nombre,apellido,clave,email");
                    return View(empleados);
                }
                UsuarioN.editarPerfil(empleados);
                return RedirectToAction("Perfil");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "ERROR AL ACTUALIZAR EL PERFIL: " + ex.Message);
                return View(empleados);
            }
        }
        public ActionResult UsuariosReporte()
        {
            if (misVariables.sioNo == 1)
            {
                
                var usR = UsuarioN.ListaUsuarios();
                return View(usR);
            }
            else
            {
                return RedirectToAction("login", "Usuario");
            }

        }

        public ActionResult Registrar()
        {
            return View();
        }
        
         [HttpPost]
        public ActionResult Registrar(Empleados empleados, string ConfirmaPass)
        {
           try
           {
                ViewBag.confPass = ConfirmaPass;
                if (empleados.nombreUsuario == null || empleados.Pass == null || empleados.email == null|| ConfirmaPass == null)
                {
                    ModelState.AddModelError("", "ERROR: No se pueden dejar campos vacios");
                    return View(empleados);
                }
                if (empleados.Pass == ConfirmaPass)
                {
                    UsuarioN.AgregarUsuario(empleados);
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "ERROR: Contraseñas no coinciden");
                    return View(empleados);
                }

           }
           catch (Exception ex)
           {
                ModelState.AddModelError("", "ERROR AL REGISTRARTE DEPARTAMENTO: " + ex.Message);
                return View(empleados);
           

           }  
        }
        [HttpPost]
        public ActionResult EliminarUsuario(int identificador)
        {
            try
            {

                UsuarioN.EliminarUsuario(identificador);
                return Json(new { ok = true, toRedirect = Url.Action("login","Usuario") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult getUsuario()
        {
            var lista = UsuarioN.ListaUsuariosEmp();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}