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
    public class DTO_Usuario
    {
        [DisplayName("Nombre de Usuario:")]
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string nombreUsuario { get; set; }

        [DisplayName("Contraseña:")]
        [Required(ErrorMessage = "La contraseña es requerida")]
        public string contraseña { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El apellido es requerido")]
        public string apellido { get; set; }
        [Required(ErrorMessage = "El teléfono es requerido")]
        public string telefono { get; set; }
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        public string correoElectronico { get; set; }

        public string userType;
    }
}
