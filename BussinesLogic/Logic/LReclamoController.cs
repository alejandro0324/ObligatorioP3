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
    public class LReclamoController
    {
        private Repository repository;

        public LReclamoController()
        {
            this.repository = new Repository();
        }

        #region TipoReclamo

        public bool ContieneReclamos(DTO_TipoReclamo dto)
        {
            return this.repository.GetTipoReclamoRepository().ContieneReclamos(dto);
        }
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

        public DTO_Reclamo ReclamoByNumero(int numero)
        {
            return this.repository.GetReclamoRepository().ReclamoByNumero(numero);
        }
        public List<DTO_Reclamo> ListarReclamosPersonales(string nombre)
        {
            return this.repository.GetReclamoRepository().ListarReclamosPersonales(nombre);
        }
        public List<DTO_Reclamo> ListarReclamos()
        {
            return this.repository.GetReclamoRepository().ListarReclamos();
        }
        public List<DTO_Reclamo> ListarReclamosActivos()
        {
            return this.repository.GetReclamoRepository().ListarReclamosActivos();
        }
        public List<string> AgregarReclamo(DTO_Reclamo dto)
        {
            List<string> colMensajes = new List<string>();
            dto.fchaHora = DateTime.Now;
            dto.estado = CGeneral.PENDIENTE;
            dto.situacion = CGeneral.ACTIVO;

            dto.numeroCuadrilla = this.FraccionadorDeCuadrillas(dto.numeroZona);

            this.repository.GetReclamoRepository().AgregarReclamo(dto);
            colMensajes.Add("Reclamo ingresado, número: " + dto.numero.ToString());

            return colMensajes;
        }
        public int? FraccionadorDeCuadrillas(int? numeroZona)
        {
            int? numeroCuadrilla = null;

            List<DTO_Cuadrilla> cuadrillas = this.repository.GetCuadrillaRepository().ListarCuadrillasByNumZona((int)numeroZona);
            cuadrillas = cuadrillas.OrderBy(o => o.DTO_Reclamo.Count()).ToList();
            if (cuadrillas.Count() > 0)
            {
                numeroCuadrilla = cuadrillas.FirstOrDefault().numero;
            }

            return numeroCuadrilla;
        }
        public void DesestimarReclamo(DTO_Reclamo dto)
        {
            this.repository.GetReclamoRepository().DesestimarReclamo(dto);
        }
        public void ModificarCuadrilla(int numero, int? numeroCuadrilla)
        {
            this.repository.GetReclamoRepository().ModificarCuadrilla(numero, numeroCuadrilla);
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
        public void ModificarReclamo(DTO_Cuadrilla cuadrilla, int numeroReclamo)
        {
            this.repository.GetReclamoRepository().ModificarReclamo(cuadrilla, numeroReclamo);
        }
        public List<string> ValidarCamposReclamo(DTO_Reclamo dto)
        {
            List<string> errores = new List<string>();

            //Validaciones

            return errores;
        }
        public string SiguienteEstado(DTO_Reclamo dto)
        {
            string siguiente = "";
            switch (dto.estado)
            {
                case "PENDIENTE": siguiente = "ASIGNADO";
                    break;
                case "ASIGNADO": siguiente = "EN PROCESO";
                    break;
                case "EN PROCESO": siguiente = "RESUELTO";
                    break;
                default:
                    break;
            }
            return siguiente;
        }
        public void ModificarEstado(DTO_Reclamo dto)
        {
            if (dto.estado == "RESUELTO")
            {
                dto.situacion = "0";
            }
            this.repository.GetReclamoRepository().ModificarEstado(dto);
        }
        public List<DTO_LogReclamo> ListarReclamosPorFechas(DateTime fechaUno, DateTime fechaDos)
        {
            return this.repository.GetLogReclamoRepository().ListarReclamosPorFechas(fechaUno, fechaDos);
        }
        public List<DTO_Reclamo> ReclamosAtrasados()
        {
            List<DTO_Reclamo> lista = new List<DTO_Reclamo>();
            lista = this.repository.GetReclamoRepository().ReclamosAtrasados();
            foreach (DTO_Reclamo item in lista)
            {
                TimeSpan cantidadHoras = (DateTime.Now - this.repository.GetLogReclamoRepository().TiempoInicialDelReclamo(item.numero));
                item.horas = Math.Truncate(cantidadHoras.TotalHours);
            }
            return lista;
        }
        public List<DTO_Reclamo> ListByEstado(string estado)
        {
            return this.repository.GetReclamoRepository().ListarReclamos(estado);
        }

        #endregion
    }
}
