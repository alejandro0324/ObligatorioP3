﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AyuntamientoToledoEntities : DbContext
    {
        public AyuntamientoToledoEntities()
            : base("name=AyuntamientoToledoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_Cuadrilla> T_Cuadrilla { get; set; }
        public virtual DbSet<T_PuntoGps> T_PuntoGps { get; set; }
        public virtual DbSet<T_Reclamo> T_Reclamo { get; set; }
        public virtual DbSet<T_TipoReclamo> T_TipoReclamo { get; set; }
        public virtual DbSet<T_Usuario> T_Usuario { get; set; }
        public virtual DbSet<T_Zona> T_Zona { get; set; }
        public virtual DbSet<T_LogReclamo> T_LogReclamo { get; set; }
    }
}
