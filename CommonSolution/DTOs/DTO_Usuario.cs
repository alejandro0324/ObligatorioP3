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
        [StringLength(20, ErrorMessage = "El nombre de usuario no puede superar los 20 caracteres")]
        public string nombreUsuario { get; set; }

        [DisplayName("Contraseña:")]
        [StringLength(20, ErrorMessage = "La contraseña no puede superar los 20 caracteres")]
        [Required(ErrorMessage = "La contraseña es requerida")]
        public string contraseña { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(20, ErrorMessage = "El nombre no puede superar los 20 caracteres")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(20, ErrorMessage = "El apellido no puede superar los 20 caracteres")]
        public string apellido { get; set; }
        [Required(ErrorMessage = "El teléfono es requerido")]
        [StringLength(20, ErrorMessage = "El teléfono no puede superar los 20 caracteres")]
        public string telefono { get; set; }
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [StringLength(50, ErrorMessage = "El correo no puede superar los 50 caracteres")]
        public string correoElectronico { get; set; }

        public string userType;
    }
}
