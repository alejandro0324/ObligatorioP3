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
    public class DTO_TipoReclamo
    {
        [DisplayName("Numero:")]
        public int id { get; set; }
        [DisplayName("Nombre:")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string nombre { get; set; }
        [DisplayName("Descripción:")]
        [Required(ErrorMessage = "La descripción es requerida")]
        public string descripcion { get; set; }
    }
}
