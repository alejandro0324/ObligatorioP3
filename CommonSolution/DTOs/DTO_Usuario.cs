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
        [Remote("ValidarNombreUsuario", "Usuario", ErrorMessage = "El nombre de usuario ya existe")]
        public string nombreUsuario { get; set; }

        [DisplayName("Contraseña:")]
        [Required(ErrorMessage = "La contraseña es requerida")]
        public string contraseña { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string telefono { get; set; }

        public string correoElectronico { get; set; }

        public string userType;
    }
}
