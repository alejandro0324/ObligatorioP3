using CommonSolution.Constantes;
using CommonSolution.DTOs;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Logic
{
    public class LLogReclamoController
    {
        private Repository repository;

        public LLogReclamoController()
        {
            this.repository = new Repository();
        }

        public List<DTO_LogReclamo> GetLogReclamosByNum(int numero)
        {
            List<DTO_LogReclamo> lista = this.repository.GetLogReclamoRepository().GetLogReclamosByNum(numero);
            return lista;
        }
        public List<DTO_LogReclamo> ListarReclamosPorFechas(DateTime fechaUno, DateTime fechaDos)
        {
            return this.repository.GetLogReclamoRepository().ListarReclamosPorFechas(fechaUno, fechaDos);
        }
        public List<DTO_LogReclamo> ListarReclamosActivos()
        {
            return this.repository.GetLogReclamoRepository().ListarReclamosActivos();
        }
    }
}
