using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class DocumentoD
    {
        public void AgregarDoc(Documentos documentos)
        {
            using (var baseDatos = new proyectofinalprogEntities())
            {
                baseDatos.Documentos.Add(documentos);
                baseDatos.SaveChanges();
            }
        }
        public List<viewDocumento> ListaDocumento1()
        {
            using (var baseDatos = new proyectofinalprogEntities())
            {
                baseDatos.Configuration.LazyLoadingEnabled = false;
                return baseDatos.viewDocumento.ToList();
            }
        }
        public List<viewDocumento2> getListPorEmp(string nombreUsu)
        {
            using (var baseDatos = new proyectofinalprogEntities())
            {
                List<viewDocumento2> lista = (from d in baseDatos.viewDocumento
                                       where d.nombreUsuario == nombreUsu
                                       select new viewDocumento2 { 
                                       secuencia = d.secuencia,
                                       nombre = d.nombre,
                                       nombreUsuario = d.nombreUsuario,
                                       Departamento_Origen = d.Departamento_Origen,
                                       Departamento_Destino = d.Departamento_Destino,
                                       fechaDocumento = d.fechaDocumento
                                       
                                       }).ToList();



                return lista;
            }
        }
        public List<viewDocumento2> ListaDocumento()
        {
            using (var baseDatos = new proyectofinalprogEntities())
            {
                List<viewDocumento2> lista = (from d in baseDatos.viewDocumento                                            
                                              select new viewDocumento2
                                              {
                                                  secuencia = d.secuencia,
                                                  nombre = d.nombre,
                                                  nombreUsuario = d.nombreUsuario,
                                                  Departamento_Origen = d.Departamento_Origen,
                                                  Departamento_Destino = d.Departamento_Destino,
                                                  fechaDocumento = d.fechaDocumento

                                              }).ToList();



                return lista;
            }
        }
        public List<viewDocumento2> getListPorDepOrigen(string nombreDep)
        {
            using (var baseDatos = new proyectofinalprogEntities())
            {
                List<viewDocumento2> lista = (from d in baseDatos.viewDocumento
                                              where d.Departamento_Origen == nombreDep
                                              select new viewDocumento2
                                              {
                                                  secuencia = d.secuencia,
                                                  nombre = d.nombre,
                                                  nombreUsuario = d.nombreUsuario,
                                                  Departamento_Origen = d.Departamento_Origen,
                                                  Departamento_Destino = d.Departamento_Destino,
                                                  fechaDocumento = d.fechaDocumento

                                              }).ToList();



                return lista;
            }
        }
        public List<viewDocumento2> getListPorDepDestino(string nombreDep)
        {
            using (var baseDatos = new proyectofinalprogEntities())
            {
                List<viewDocumento2> lista = (from d in baseDatos.viewDocumento
                                              where d.Departamento_Destino == nombreDep
                                              select new viewDocumento2
                                              {
                                                  secuencia = d.secuencia,
                                                  nombre = d.nombre,
                                                  nombreUsuario = d.nombreUsuario,
                                                  Departamento_Origen = d.Departamento_Origen,
                                                  Departamento_Destino = d.Departamento_Destino,
                                                  fechaDocumento = d.fechaDocumento

                                              }).ToList();



                return lista;
            }
        }
        public List<viewDocumento2> getListPorFecha(string inicio,string final)
        {
            System.DateTime inicio1 = Convert.ToDateTime(inicio);
            System.DateTime final1 = Convert.ToDateTime(final);
            System.Diagnostics.Debug.WriteLine("esto te permite imprimir cosas en consola y ver klk " + inicio1 +" a ver "+ final1);
            using (var baseDatos = new proyectofinalprogEntities())
            {
                List<viewDocumento2> lista = (from d in baseDatos.viewDocumento
                                              where d.fechaDocumento >= inicio1 && d.fechaDocumento <= final1
                                              select new viewDocumento2
                                              {
                                                  secuencia = d.secuencia,
                                                  nombre = d.nombre,
                                                  nombreUsuario = d.nombreUsuario,
                                                  Departamento_Origen = d.Departamento_Origen,
                                                  Departamento_Destino = d.Departamento_Destino,
                                                  fechaDocumento = d.fechaDocumento

                                              }).ToList();



                return lista;
            }
        }


    }
}
