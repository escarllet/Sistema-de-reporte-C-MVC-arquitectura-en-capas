using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class UsuarioN
    {
        private static UsuarioD objeDeDatos = new UsuarioD();

        public static List<viewEmpleados> ListaUsuarios()
        {
            return objeDeDatos.ListaUsuarios();
        }
        public static List<Empleados> ListaUsuariosEmp()
        {
            return objeDeDatos.ListaUsuariosEmp();
        }
        public static string ElDepartamento(string correo)
        {
            string co = "defaul";
            List<viewEmpleados> ListaUsuarios = objeDeDatos.ListaUsuarios();
            foreach (var item in ListaUsuarios)
            {
                
                if (item.email.Trim() == correo)
                {
                    co = item.nombreDep;
                }
                else
                {
                    
                }
            }
            ElDepartamentoid();
            return co;

        }
        public static void ElDepartamentoid()
        {
            int? co = 0;
            List<Empleados> ListaUsuarios = objeDeDatos.ListaUsuariosEmp();
            foreach (var item in ListaUsuarios)
            {

                if (item.email.Trim() == misVariables.correo)
                {
                    co = item.idDepartamento;
                }
                else
                {

                }
            }

            misVariables.idDep = (int)co;
        }
        public static void AgregarUsuario(Empleados empleados)
        {

            objeDeDatos.AgregarUsuario(empleados);
        }
        public static int GetUsuario(Empleados empleados)
        {
            return objeDeDatos.GetUsuario(empleados);

        }
        public static Empleados GetUsuarioEmail(int id)
        {
            return objeDeDatos.GetUsuarioEmail(id);
        }
        public static void editarPerfil(Empleados empleados)
        {
            objeDeDatos.editarPerfil(empleados);
        }
        public static int getIdporEmail(string correo)
        {
           return objeDeDatos.getIdporEmail(correo);
        }
        public static void EliminarUsuario(int id)
        {
            objeDeDatos.EliminarUsuario(id);
        }
    }
}
