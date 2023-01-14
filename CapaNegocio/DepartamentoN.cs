using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class DepartamentoN
    {
        
        private static DepartamentoD objeDeDatos = new DepartamentoD();

        public static List<Departamentos> ListaDepartamentos()
        {
            return objeDeDatos.ListaDepartamentos();
        }
        public static void AgregarDep(Departamentos depto)
        {

            objeDeDatos.AgregarDep(depto);
        }
        public static void editarDep(Departamentos departamentos)
        {
            objeDeDatos.editarDep(departamentos);
        }
        public static Departamentos GetDepartamento(int id)
        {
            return objeDeDatos.GetDepartamento(id);

        }
        public static void EliminarDep(int id)
        {
            objeDeDatos.EliminarDep(id);
        }
        //para la secuencia
        public static string ElDepartamentoSiglas(int id)
        {
            string co = "defaul";
            List<Departamentos> ListaDepar = objeDeDatos.ListaDepartamentos();
            foreach (var item in ListaDepar)
            {

                if (item.id == id)
                {
                    co = item.siglas;
                }
                else
                {

                }
            }
            
            return co;

        }
    }
}
