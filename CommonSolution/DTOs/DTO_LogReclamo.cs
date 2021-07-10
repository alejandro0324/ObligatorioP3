using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class DTO_LogReclamo
    {
        public string nombreCliente;

        public string nombreFuncionario;

        public int numReclamo;

        public string tipoReclamo;

        public string latitud;

        public string longitud;

        public DateTime? fechaHora;

        public string estado;

        public string observacionesCiudadano;

        public string observacionesCuadrilla;

        public string comentarioFuncionario;
    }
}
