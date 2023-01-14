using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using CapaEntidad;

namespace proyecto_final.Controllers
{
    public class DocumentosController : Controller
    {
        // GET: Documentos
        public ActionResult CrearDocumento()
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

        [HttpPost]
        public ActionResult CrearDocumento(int identificador)
        {
            try
            {
                
                Documentos documentos = new Documentos();

                documentos.idDepEmpleado = misVariables.idDep;
                documentos.idEmpleado = misVariables.id;
                documentos.fechaDocumento = DateTime.Now.Date;
                documentos.idDepDestino = identificador;

                //secuencia
                
                string ano = Convert.ToString(DateTime.Now.Year);
                string depOri = DepartamentoN.ElDepartamentoSiglas(misVariables.idDep);
                string depDes = DepartamentoN.ElDepartamentoSiglas(identificador);
                misVariables.Contador += 1;
                int numero = misVariables.Contador;
                string secue = ano + "-" + depOri.Trim() + "-" + depDes.Trim() + "-00" + numero;

                documentos.secuencia = secue; 

                DocumentoN.AgregarDoc(documentos);

                return Json(new { ok = true, toRedirect = Url.Action("TodosDocumentos", "Documentos") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult TodosDocumentos()
        {
            if (misVariables.sioNo == 1)
            {
               
                var dep = DocumentoN.ListaDocumento();
                return View(dep);
            }
            else
            {
                return RedirectToAction("login", "Usuario");
            }
        }
        public ActionResult BuscarReporte()
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
        //buscar empleado
        [HttpPost]
        public ActionResult BuscarPorEmp(string identificador)
        {
            try
            {

                //tengo que mandar el id (listo)
                //y buscar en la base de datos por ese id de empleado, y hacer una lista con esto
                //para finalmente mostrarlo en una vista
                misVariables.ListBuscar = DocumentoN.getListPorEmp(identificador.Trim());
                misVariables.loquesebusca = "Buscar Por Empleado";
                return Json(new { ok = true, toRedirect = Url.Action("BuscarPor", "Documentos") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult BuscarPor()
        {
            if (misVariables.sioNo == 1)
            {


                return View(misVariables.ListBuscar);
            }
            else
            {
                return RedirectToAction("login", "Usuario");
            }
        }
        //buscar dep Origen
        [HttpPost]
        public ActionResult BuscarPorDepOri(string identificador)
        {
            try
            {

                //tengo que mandar el id (listo)
                //y buscar en la base de datos por ese id de empleado, y hacer una lista con esto
                //para finalmente mostrarlo en una vista
                misVariables.ListBuscar = DocumentoN.getListPorDepOrigen(identificador.Trim());
                misVariables.loquesebusca = "Buscar Por Departamento de origen";
                return Json(new { ok = true, toRedirect = Url.Action("BuscarPor", "Documentos") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //buscar dep Destino
        [HttpPost]
        public ActionResult BuscarPorDepDes(string identificador)
        {
            try
            {

                //tengo que mandar el id (listo)
                //y buscar en la base de datos por ese id de empleado, y hacer una lista con esto
                //para finalmente mostrarlo en una vista
                misVariables.ListBuscar = DocumentoN.getListPorDepDestino(identificador.Trim());
                misVariables.loquesebusca = "Buscar Por Departamento de destino";
                return Json(new { ok = true, toRedirect = Url.Action("BuscarPor", "Documentos") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult BuscarPorFecha(string inicio,string final)
        {
            try
            {

                //tengo que mandar el id (listo)
                //y buscar en la base de datos por ese id de empleado, y hacer una lista con esto
                //para finalmente mostrarlo en una vista

               misVariables.ListBuscar = DocumentoN.getListPorFecha(inicio,final);
               misVariables.loquesebusca = "Buscar Por Rango de fecha";
                return Json(new { ok = true, toRedirect = Url.Action("BuscarPor", "Documentos") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
