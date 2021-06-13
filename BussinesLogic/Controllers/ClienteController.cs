using CommonSolution.DTOs;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controllers
{
    public class ClienteController
    {
        private Repository repository;

        public ClienteController()
        {
            this.repository = new Repository();
        }

        #region Reclamo

        public List<DTO_Reclamo> ListarReclamo()
        {
            return this.repository.GetReclamoRepository().ListarReclamo();
        }
        public List<string> AgregarReclamo(DTO_Reclamo dto)
        {
            List<string> colErrores = this.ValidarReclamo(dto);

            if (colErrores.Count == 0)
            {
                this.repository.GetReclamoRepository().AgregarReclamo(dto);
            }

            return colErrores;
        }
        public void BorrarReclamo(int numReclamo)
        {
            this.repository.GetReclamoRepository().BorrarReclamo(numReclamo);
        }
        public List<string> ValidarReclamo(DTO_Reclamo dto)
        {
            List<string> errores = new List<string>();

            //Validaciones

            return errores;
        }

        #endregion
    }
}
