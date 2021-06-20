//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class T_Reclamo
    {
        public int numero { get; set; }
        public Nullable<float> latitud { get; set; }
        public Nullable<float> longitud { get; set; }
        public string observacionesCiudadano { get; set; }
        public string observacionesCuadrilla { get; set; }
        public string comentarioFuncionario { get; set; }
        public Nullable<System.DateTime> fechahora { get; set; }
        public string estado { get; set; }
        public string nombreUsuario { get; set; }
        public Nullable<int> IdTipoReclamo { get; set; }
        public Nullable<int> numeroZona { get; set; }
        public Nullable<int> numeroCuadrilla { get; set; }
    
        public virtual T_Cuadrilla T_Cuadrilla { get; set; }
        public virtual T_Usuario T_Usuario { get; set; }
        public virtual T_Zona T_Zona { get; set; }
        public virtual T_TipoReclamo T_TipoReclamo { get; set; }
    }
}
