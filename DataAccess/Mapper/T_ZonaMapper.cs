using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class T_ZonaMapper
    {
        public T_Zona toEnt(DTO_Zona dto)
        {
            if (dto == null)
                return null;

            return new T_Zona()
            {
                color = dto.color,
                nombre = dto.nombre,
                IdPuntoGps = dto.idPuntoGPS,
                numero = dto.numero
            };
        }

        public DTO_Zona toMap(T_Zona ent)
        {
            if (ent == null)
                return null;

            return new DTO_Zona()
            {
                color = ent.color,
                nombre = ent.nombre,
                idPuntoGPS = ent.IdPuntoGps,
                numero = ent.numero
            };
        }

        public List<T_Zona> toEnt(List<DTO_Zona> dto)
        {
            List<T_Zona> toEnt = new List<T_Zona>();
            foreach (DTO_Zona item in dto)
            {
                toEnt.Add(this.toEnt(item));
            }
            return toEnt;
        }

        public List<DTO_Zona> toMap(List<T_Zona> ent)
        {
            List<DTO_Zona> toMap = new List<DTO_Zona>();
            foreach (T_Zona item in ent)
            {
                toMap.Add(this.toMap(item));
            }
            return toMap;
        }
    }
}
