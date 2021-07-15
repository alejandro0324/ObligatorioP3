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
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string nombre { get; set; }
        [DisplayName("Descripción:")]
        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(100, ErrorMessage = "La descripción no puede superar los 100 caracteres")]
        public string descripcion { get; set; }
    }
}
