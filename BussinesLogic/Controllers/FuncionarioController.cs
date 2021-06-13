using CommonSolution.DTOs;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controllers
{
    public class FuncionarioController
    {
        private Repository repository;

        public FuncionarioController()
        {
            this.repository = new Repository();
        }

        #region Zona

        public List<DTO_Zona> ListarZonas()
        {
            return this.repository.GetZonaRepository().ListarZonas();
        }
        public List<string> AgregarZona(DTO_Zona dto)
        {
            List<string> colErrores = this.ValidarZona(dto);

            if (colErrores.Count == 0)
            {
                this.repository.GetZonaRepository().AgregarZona(dto);
            }

            return colErrores;
        }
        public void BorrarZona(int numZona)
        {
            this.repository.GetZonaRepository().BorrarZona(numZona);
        }
        public List<string> ValidarZona(DTO_Zona dto)
        {
            List<string> errores = new List<string>();

            //Validaciones

            return errores;
        }

        #endregion

        #region Cuadrilla

        public List<DTO_Cuadrilla> ListarCuadrillas()
        {
            return this.repository.GetCuadrillaRepository().ListarCuadrillas();
        }
        public List<string> ModificarCuadrilla(DTO_Cuadrilla dto)
        {
            List<string> colErrores = this.ValidarCamposCuadrilla(dto);

            if (colErrores.Count == 0)
            {
                this.repository.GetCuadrillaRepository().ModificarCuadrilla(dto);
            }

            return colErrores;
        }
        public List<string> AgregarCuadrilla(DTO_Cuadrilla dto)
        {
            List<string> colErrores = this.ValidarCamposCuadrilla(dto);

            if (colErrores.Count == 0)
            {
                this.repository.GetCuadrillaRepository().AgregarCuadrilla(dto);
            }

            return colErrores;
        }
        public void BorrarCuadrilla(int numZona)
        {
            this.repository.GetCuadrillaRepository().BorrarCuadrilla(numZona);
        }
        public List<string> ValidarCamposCuadrilla(DTO_Cuadrilla dto)
        {
            List<string> errores = new List<string>();

            //Validaciones

            return errores;
        }

        #endregion

        #region TipoReclamo

        public List<DTO_TipoReclamo> ListarTipoReclamo()
        {
            return this.repository.GetTipoReclamoRepository().ListarTipoReclamo();
        }
        public List<string> AgregarTipoReclamo(DTO_TipoReclamo dto)
        {
            List<string> colErrores = this.ValidarCamposTipoReclamo(dto);

            if (colErrores.Count == 0)
            {
                this.repository.GetTipoReclamoRepository().AgregarTipoReclamo(dto);
            }

            return colErrores;
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
