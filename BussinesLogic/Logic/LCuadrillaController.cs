using CommonSolution.DTOs;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controllers
{
    public class LCuadrillaController
    {
        private Repository repository;

        public LCuadrillaController()
        {
            this.repository = new Repository();
        }

        #region Cuadrilla

        public List<DTO_Cuadrilla> ListarCuadrillas()
        {
            return this.repository.GetCuadrillaRepository().ListarCuadrillas();
        }
        public void ModificarCuadrilla(DTO_Cuadrilla dto)
        {
            this.repository.GetCuadrillaRepository().ModificarCuadrilla(dto);
        }
        public List<string> AgregarCuadrilla(DTO_Cuadrilla dto)
        {
            List<string> colMensajes = this.ValidarCamposCuadrilla(dto);

            if (colMensajes.Count == 0)
            {
                this.repository.GetCuadrillaRepository().AgregarCuadrilla(dto);
                colMensajes.Add("Cuadrilla agregada con éxito");
            }

            return colMensajes;
        }
        public void BorrarCuadrilla(int numCuadrilla)
        {
            this.repository.GetCuadrillaRepository().BorrarCuadrilla(numCuadrilla);
        }
        public bool ExisteCuadrilla(int numCuadrilla)
        {
            return this.repository.GetCuadrillaRepository().ExisteCuadrilla(numCuadrilla);
        }
        public DTO_Cuadrilla CuadrillaByNumero(int numero)
        {
            return this.repository.GetCuadrillaRepository().CuadrillaByNumero(numero);
        }
        public List<string> ValidarCamposCuadrilla(DTO_Cuadrilla dto)
        {
            List<string> errores = new List<string>();

            //Validaciones

            return errores;
        }

        #endregion
    }
}
