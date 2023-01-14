using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class UsuarioD
    {
        public List<viewEmpleados> ListaUsuarios()
        {
            try
            {
                using (var baseDatos = new proyectofinalprogEntities())
                {
                    baseDatos.Configuration.LazyLoadingEnabled = false;
                    return baseDatos.viewEmpleados.ToList();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("esto te permite imprimir cosas en consola y ver klk " + ex);
                throw;
            }

        }
        public List<Empleados> ListaUsuariosEmp()
        {
            try
            {
                using (var baseDatos = new proyectofinalprogEntities())
                {
                    baseDatos.Configuration.LazyLoadingEnabled = false;
                    return baseDatos.Empleados.ToList();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("esto te permite imprimir cosas en consola y ver klk " + ex);
                throw;
            }

        }
        public void AgregarUsuario(Empleados empleados)
        {
            using (var baseDatos = new proyectofinalprogEntities())
            {
                baseDatos.Empleados.Add(empleados);
                baseDatos.SaveChanges();
            }
        }
        public int GetUsuario(Empleados empleados)
        {
            bool existe;
            Empleados blog;
            using (var baseDatos = new proyectofinalprogEntities())
            {
                blog = baseDatos.Empleados
                .Where(b => b.email == empleados.email)
                .FirstOrDefault();

                existe = baseDatos.Empleados.Any(x => x.email == empleados.email && x.Pass == empleados.Pass);
            }
            if (existe)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public Empleados GetUsuarioEmail(int id)
        {
            using (var baseDatos = new proyectofinalprogEntities())
            {
                return baseDatos.Empleados.Find(id);
            }
        }
        public int getIdporEmail(string correo)
        {
            using (var baseDatos = new proyectofinalprogEntities())
            {
                List<Emplea2> lista = (from d in baseDatos.Empleados
                          where d.email == correo
                          select new Emplea2 { id = d.id}).ToList();


                int ide = lista[0].id;
                return ide;
            }
        }

        public void editarPerfil(Empleados empleados)
        {
            using (var baseDatos = new proyectofinalprogEntities())
            {
                
                var d = baseDatos.Empleados.Find(empleados.id);
                d.nombreUsuario = empleados.nombreUsuario;
                d.nombre = empleados.nombre;
                d.apellido = empleados.apellido;
                d.email = empleados.email;
                d.Pass = empleados.Pass;
                d.direccion = empleados.direccion;
                d.provincia = empleados.provincia;
                d.ciudad = empleados.ciudad;
                d.cargo = empleados.cargo;
                d.zipcode = empleados.zipcode;

                baseDatos.SaveChanges();
            }
        }
        public void EliminarUsuario(int id)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("esto te permite imprimir cosas en consola y ver klk" + id);

                using (var baseDatos = new proyectofinalprogEntities())
                {
                    var d = baseDatos.Empleados.Find(id);
                    baseDatos.Empleados.Remove(d);
                    baseDatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine("esto te permite imprimir cosas en consola y ver klk " + ex);
                throw;
            }

        }
    }
}
