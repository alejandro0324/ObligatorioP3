using CommonSolution.Constantes;
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

        public void ActivarCuadrilla(int numCuadrilla)
        {
            this.repository.GetCuadrillaRepository().ActivarCuadrilla(numCuadrilla);
        }
        public List<DTO_Cuadrilla> ListarCuadrillasByNumZona(int numeroZona)
        {
            return this.repository.GetCuadrillaRepository().ListarCuadrillasByNumZona(numeroZona);
        }
        public bool ContieneReclamos(DTO_Cuadrilla dto)
        {
            return this.repository.GetCuadrillaRepository().ContieneReclamos(dto);
        }
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
                dto.situacion = CGeneral.ACTIVO;
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
        public List<DTO_Reclamo> GetReclamos(int numero)
        {
            List<DTO_Reclamo> lista = new List<DTO_Reclamo>();
            lista = this.repository.GetReclamoRepository().ListarReclamosByCuadrilla(numero);
            return lista;
        }
        public double? CalcularPromedio(int numero)
        {
            double? promedio = null;
            int cantidadReclamos = 0;
            double tiempoFinalizacionPromedio = 0;

            List<DTO_Reclamo> lista = new List<DTO_Reclamo>();
            lista = this.repository.GetReclamoRepository().ListarReclamosFinalizadosByCuadrilla(numero);
            cantidadReclamos = lista.Count();
            double tiempoFinalizacionHoras = 0;
            foreach (var item in lista)
            {
                tiempoFinalizacionHoras = tiempoFinalizacionHoras + this.repository.GetLogReclamoRepository().TiempoDeFinalizaciónPromedio(item.numero);
            }
            tiempoFinalizacionPromedio = tiempoFinalizacionHoras / lista.Count();
            promedio = cantidadReclamos / tiempoFinalizacionPromedio;
            if (double.IsNaN((double)promedio))
            {
                promedio = 0;
            }

            return promedio;
        }

        #endregion
    }
}
