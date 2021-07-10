using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CommonSolution.DTOs
{
    public class DTO_Cuadrilla
    {   
        [Range(0.0, int.MaxValue, ErrorMessage = "El número debe ser mayor a {1}.")]
        [Remote("ValidarNumero", "Cuadrilla", ErrorMessage = "Ya existe una cuadrilla con ese número")]
        [DisplayName("Número:")] 
        [Required(ErrorMessage = "El número es requerido")]
        public int numero { get; set; }

        [DisplayName("Nombre:")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string nombre { get; set; }

        [DisplayName("Cantidad de peones:")]
        [Required(ErrorMessage = "La cantidad de peones es requerida")]
        public int? cantidadPeones { get; set; }

        public string situacion;

        public int numZona { get; set; }

        public DTO_Zona DTO_Zona;

        public DTO_Reclamo DTO_Reclamo;
    }
}
