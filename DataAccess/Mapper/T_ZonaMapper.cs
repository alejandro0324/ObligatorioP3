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
                numero = dto.numero,
                situacion = dto.situacion
            };
        }

        public DTO_Zona toMap(T_Zona ent)
        {
            if (ent == null)
                return null;

            List<DTO_PuntoGPS> puntoGPS = new List<DTO_PuntoGPS>();
            T_PuntoGPSMapper mapper = new T_PuntoGPSMapper();
            foreach (var item in ent.T_PuntoGps)
            {
                puntoGPS.Add(mapper.toMap(item));
            }

            return new DTO_Zona()
            {
                color = ent.color,
                nombre = ent.nombre,
                numero = ent.numero,
                situacion = ent.situacion,
                puntosGps = puntoGPS,
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
