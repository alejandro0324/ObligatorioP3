using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class T_PuntoGPSMapper
    {
        public T_PuntoGps toEnt(DTO_PuntoGPS dto)
        {
            if (dto == null)
                return null;

            return new T_PuntoGps()
            {
                id = dto.id,
                latitud = dto.latitud,
                longitud = dto.longitud,
                idNumeroZona = dto.idZona
            };
        }

        public DTO_PuntoGPS toMap(T_PuntoGps ent)
        {
            if (ent == null)
                return null;

            return new DTO_PuntoGPS()
            {
                id = ent.id,
                latitud = ent.latitud,
                longitud = ent.longitud,
                idZona = (int)ent.idNumeroZona
            };
        }

        public List<T_PuntoGps> toEnt(List<DTO_PuntoGPS> dto)
        {
            List<T_PuntoGps> toEnt = new List<T_PuntoGps>();
            foreach (DTO_PuntoGPS item in dto)
            {
                toEnt.Add(this.toEnt(item));
            }
            return toEnt;
        }

        public List<DTO_PuntoGPS> toMap(List<T_PuntoGps> ent)
        {
            List<DTO_PuntoGPS> toMap = new List<DTO_PuntoGPS>();
            foreach (T_PuntoGps item in ent)
            {
                toMap.Add(this.toMap(item));
            }
            return toMap;
        }
    }
}
