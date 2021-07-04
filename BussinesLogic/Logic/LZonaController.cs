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

        public bool ContieneReclamos(DTO_Zona dto)
        {
            return this.repository.GetZonaRepository().ContieneReclamos(dto);
        }
        public DTO_Zona ZonaByNumero(int numero)
        {
            return this.repository.GetZonaRepository().ZonaByNumero(numero);
        }
        public bool ExisteZona(int numero)
        {
            return this.repository.GetZonaRepository().ExisteZona(numero);
        }
        public List<DTO_Zona> ListarZonas()
        {
            return this.repository.GetZonaRepository().ListarZonas();
        }
        public List<DTO_Zona> ListarZonasActivas()
        {
            return this.repository.GetZonaRepository().ListarZonasActivas();
        }
        public List<string> AgregarZona(List<string> puntosGps, string color, string nombre, string numero)
        {
            List<string> colMensajes = this.ValidarZona(nombre, numero);

            if (colMensajes.Count == 0)
            {
                DTO_Zona dto = new DTO_Zona();
                dto.color = color;
                dto.nombre = nombre;
                dto.numero = int.Parse(numero);
                List<DTO_PuntoGPS> dtoGps = new List<DTO_PuntoGPS>();
                dto.puntosGps = dtoGps;
                dto.situacion = "1";
                this.repository.GetZonaRepository().AgregarZona(dto);
                foreach (string item in puntosGps)
                {
                    string[] split = item.Split(',');
                    string longitud = split[0];
                    string latitud = split[1];
                    DTO_PuntoGPS puntoGPS = new DTO_PuntoGPS();
                    puntoGPS.latitud = latitud;
                    puntoGPS.longitud = longitud;
                    puntoGPS.idZona = int.Parse(numero);
                    this.AgregarPuntoGPS(puntoGPS);
                    dto.puntosGps.Add(puntoGPS);
                }
                colMensajes.Add("Zona agregada con éxito");
            }
            
            return colMensajes;
        }
        public void BorrarZona(int numZona)
        {
            this.repository.GetZonaRepository().BorrarZona(numZona);
        }
        public void ActivarZona(int numZona)
        {
            this.repository.GetZonaRepository().ActivarZona(numZona);
        }
        public List<string> ValidarZona(string nombre, string numero)
        {
            List<string> errores = new List<string>();

            if (string.IsNullOrEmpty(nombre))
            {
                errores.Add("El nombre es requerido");
            }
            if (nombre.Length > 20)
            {
                errores.Add("El nombre es demasiado largo");
            }
            if (string.IsNullOrEmpty(numero))
            {
                errores.Add("El número es requerido");
            }
            else
            {
                if (int.Parse(numero) < 0)
                {
                    errores.Add("El número debe ser es positivo");
                }
                if (this.ExisteZona(int.Parse(numero)))
                {
                    errores.Add("Ya existe una zona con ese número");
                }
            }

            return errores;
        }

        #endregion

        #region PuntoGPS

        public DTO_PuntoGPS AgregarPuntoGPS(DTO_PuntoGPS dto)
        {
            return this.repository.GetPuntoGpsRepository().AgregarPuntoGps(dto);
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
