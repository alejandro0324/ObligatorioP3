using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class DTO_Reclamo
    {
        public int numero { get; set; }

        public string latitud { get; set; }

        public string longitud { get; set; }

        [DisplayName("Observaciones: ")]
        [StringLength(100, ErrorMessage = "El comentario no puede superar los 100 caracteres")]
        public string observacionesCiudadano { get; set; }

        public string comentarioFuncionario { get; set; }

        public DateTime? fchaHora;

        public string estado;

        public string nombreFuncionario;

        public string nombreCliente;

        public int? idTipoReclamo { get; set; }

        public int? numeroZona;

        public int? numeroCuadrilla;

        public string situacion;

        public DTO_TipoReclamo tipoReclamo;

        public DTO_Zona zona { get; set; }

        public DTO_Cuadrilla cuadrilla { get; set; }

        public double horas;
    }
}
