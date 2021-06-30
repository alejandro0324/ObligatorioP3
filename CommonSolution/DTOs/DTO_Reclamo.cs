using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class DTO_Reclamo
    {
        public int numero;

        public float? latitud;

        public float? longitud;

        public string observacionesCuadrilla;

        public string observacionesCiudadano;

        public string comentarioFuncionario;

        public DateTime? fchaHora;

        public string estado;

        public string nombreUsuario;

        public int? idTipoReclamo;

        public int? numeroZona;

        public int? numeroCuadrilla;

        public string situacion;
    }
}
