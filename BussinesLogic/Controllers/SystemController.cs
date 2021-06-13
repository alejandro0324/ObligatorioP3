using CommonSolution.DTOs;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controllers
{
    public class SystemController
    {
        private Repository repository;

        public SystemController()
        {
            this.repository = new Repository();
        }

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

        //Login y Signin
    }
}
