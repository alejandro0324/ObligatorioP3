using CommonSolution.DTOs;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Logic
{
    public class LReclamoController
    {
        private Repository repository;

        public LReclamoController()
        {
            this.repository = new Repository();
        }

        #region TipoReclamo

        public bool ExisteId(int id)
        {
            return this.repository.GetTipoReclamoRepository().ExisteId(id);
        }
        public DTO_TipoReclamo tipoReclamoById(int id)
        {
            return this.repository.GetTipoReclamoRepository().tipoReclamoById(id);
        }
        public List<DTO_TipoReclamo> ListarTipoReclamo()
        {
            return this.repository.GetTipoReclamoRepository().ListarTipoReclamo();
        }
        public List<string> AgregarTipoReclamo(DTO_TipoReclamo dto)
        {
            List<string> colMensajes = this.ValidarCamposTipoReclamo(dto);

            if (colMensajes.Count == 0)
            {
                this.repository.GetTipoReclamoRepository().AgregarTipoReclamo(dto);
                colMensajes.Add("Tipo de reclamo agregado correctamente");
            }

            return colMensajes;
        }
        public List<string> ModificarTipoReclamo(DTO_TipoReclamo dto)
        {
            List<string> colErrores = this.ValidarCamposTipoReclamo(dto);

            if (colErrores.Count == 0)
            {
                this.repository.GetTipoReclamoRepository().ModificarTipoReclamo(dto);
            }

            return colErrores;
        }
        public void BorrarTipoReclamo(int numZona)
        {
            this.repository.GetTipoReclamoRepository().BorrarTipoReclamo(numZona);
        }
        public List<string> ValidarCamposTipoReclamo(DTO_TipoReclamo dto)
        {
            List<string> errores = new List<string>();

            //Validaciones

            return errores;
        }

        #endregion

        #region Reclamo

        public List<DTO_Reclamo> ListarReclamo()
        {
            return this.repository.GetReclamoRepository().ListarReclamo();
        }
        public List<string> AgregarReclamo(DTO_Reclamo dto)
        {
            List<string> colErrores = this.ValidarCamposReclamo(dto);

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
        public List<string> ModificarReclamo(DTO_Reclamo dto)
        {
            List<string> colErrores = this.ValidarCamposReclamo(dto);

            if (colErrores.Count == 0)
            {
                this.repository.GetReclamoRepository().ModificarReclamo(dto);
            }

            return colErrores;
        }
        public List<string> ValidarCamposReclamo(DTO_Reclamo dto)
        {
            List<string> errores = new List<string>();

            //Validaciones

            return errores;
        }

        #endregion
    }
}
