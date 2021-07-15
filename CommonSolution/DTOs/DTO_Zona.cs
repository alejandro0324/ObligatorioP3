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
    public class DTO_Zona
    {
        [DisplayName("Número:")]
        public int numero { get; set; }
        [DisplayName("Nombre:")]
        [StringLength(20, ErrorMessage = "El nombre no puede superar los 20 caracteres")]
        public string nombre { get; set; }
        [DisplayName("Color:")]
        public string color { get; set; }

        public string situacion;

        public List<DTO_PuntoGPS> puntosGps;

        public List<DTO_Cuadrilla> cuadrillas;
    }
}
