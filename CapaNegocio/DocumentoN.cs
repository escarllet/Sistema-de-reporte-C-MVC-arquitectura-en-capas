using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
    public class DocumentoN
    {
        private static DocumentoD objeDeDatos = new DocumentoD();
        public static void AgregarDoc(Documentos documentos)
        {
            objeDeDatos.AgregarDoc(documentos);
        }
        public static List<viewDocumento2> ListaDocumento()
        {
            return objeDeDatos.ListaDocumento();
        }
        public static List<viewDocumento2> getListPorEmp(string nombreUsu)
        {
            return objeDeDatos.getListPorEmp(nombreUsu);
        }
        public static List<viewDocumento2> getListPorDepOrigen(string nombreDep)
        {
            return objeDeDatos.getListPorDepOrigen(nombreDep);
        }
        public static List<viewDocumento2> getListPorDepDestino(string nombreDep)
        {
            return objeDeDatos.getListPorDepDestino(nombreDep);
        }
        public static List<viewDocumento2> getListPorFecha(string inicio, string final)
        {
            return objeDeDatos.getListPorFecha( inicio, final);
        }
    }
}
