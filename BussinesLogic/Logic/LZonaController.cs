using CommonSolution.DTOs;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controllers
{
    public class LZonaController
    {
        private Repository repository;

        public LZonaController()
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

        #region PuntoGPS

        public void AgregarPuntoGPS(DTO_PuntoGPS dto)
        {
            this.repository.GetPuntoGpsRepository().AgregarPuntoGps(dto);
        }
        public void BorrarPuntoGPS(int id)
        {
            this.repository.GetPuntoGpsRepository().BorrarPuntoGps(id);
        }
        public void ModificarPuntoGps(DTO_PuntoGPS dto)
        {
            this.repository.GetPuntoGpsRepository().ModificarPuntoGps(dto);
        }

        #endregion
    }
}
