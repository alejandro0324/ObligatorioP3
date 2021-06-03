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
        public T_PuntoGPS toEnt(DTO_PuntoGPS dto)
        {
            if (dto == null)
                return null;

            return new T_PuntoGPS()
            {
                Id = dto.id,
                latitud = dto.latitud,
                longitud = dto.longitud
            };
        }

        public DTO_PuntoGPS toMap(T_PuntoGPS ent)
        {
            if (ent == null)
                return null;

            return new DTO_PuntoGPS()
            {
                id = ent.Id,
                latitud = ent.latitud,
                longitud = ent.longitud
            };
        }

        public List<T_PuntoGPS> toEnt(List<DTO_PuntoGPS> dto)
        {
            List<T_PuntoGPS> toEnt = new List<T_PuntoGPS>();
            foreach (DTO_PuntoGPS item in dto)
            {
                toEnt.Add(this.toEnt(item));
            }
            return toEnt;
        }

        public List<DTO_PuntoGPS> toMap(List<T_PuntoGPS> ent)
        {
            List<DTO_PuntoGPS> toMap = new List<DTO_PuntoGPS>();
            foreach (T_PuntoGPS item in ent)
            {
                toMap.Add(this.toMap(item));
            }
            return toMap;
        }
    }
}
