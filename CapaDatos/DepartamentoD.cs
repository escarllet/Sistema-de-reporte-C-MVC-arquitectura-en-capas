using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class DepartamentoD
    {
        
        public List<Departamentos> ListaDepartamentos()
        {
            using (var baseDatos = new proyectofinalprogEntities())
            {
                baseDatos.Configuration.LazyLoadingEnabled = false;
                return baseDatos.Departamentos.ToList();
            }
        }

        public void AgregarDep(Departamentos depto)
        {
            using (var baseDatos = new proyectofinalprogEntities())
            {
                baseDatos.Departamentos.Add(depto);
                baseDatos.SaveChanges();
            }
        }
        public void editarDep(Departamentos departamentos)
        {
            using (var baseDatos = new proyectofinalprogEntities())
            {
                var d = baseDatos.Departamentos.Find(departamentos.id);
                d.nombreDep = departamentos.nombreDep;
                d.siglas = departamentos.siglas;
                baseDatos.SaveChanges();
            }
        }
        public Departamentos GetDepartamento(int id)
        {
            using (var baseDatos = new proyectofinalprogEntities())
            {
                return baseDatos.Departamentos.Find(id);
            }
        }
        public void EliminarDep(int id)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("esto te permite imprimir cosas en consola y ver klk"+id);

                using (var baseDatos = new proyectofinalprogEntities())
                {
                    var d = baseDatos.Departamentos.Find(id);
                    baseDatos.Departamentos.Remove(d);
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
