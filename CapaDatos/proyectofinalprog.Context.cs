﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using CapaEntidad;
    public partial class proyectofinalprogEntities : DbContext
    {
        public proyectofinalprogEntities()
            : base("name=proyectofinalprogEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<viewEmpleados> viewEmpleados { get; set; }
        public virtual DbSet<Documentos> Documentos { get; set; }
        public virtual DbSet<viewDocumento> viewDocumento { get; set; }
    
        public virtual ObjectResult<Nullable<int>> busLogin(string emaill, string passs)
        {
            var emaillParameter = emaill != null ?
                new ObjectParameter("emaill", emaill) :
                new ObjectParameter("emaill", typeof(string));
    
            var passsParameter = passs != null ?
                new ObjectParameter("passs", passs) :
                new ObjectParameter("passs", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("busLogin", emaillParameter, passsParameter);
        }
    }
}
