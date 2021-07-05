using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public string observacionesCuadrilla;

        [DisplayName("Observaciones: ")]
        public string observacionesCiudadano { get; set; }

        public string comentarioFuncionario;

        public DateTime? fchaHora;

        public string estado;

        public string nombreUsuario;

        public int? idTipoReclamo { get; set; }

        public int? numeroZona;

        public int? numeroCuadrilla;

        public string situacion;

        public DTO_TipoReclamo tipoReclamo;

        public DTO_Zona zona { get; set; }

        public DTO_Cuadrilla cuadrilla { get; set; }
    }
}
