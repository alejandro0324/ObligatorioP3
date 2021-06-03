using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class T_CiudadanoMapper
    {
        public T_Ciudadano toEnt(DTO_Ciudadano dto)
        {
            if (dto == null)
                return null;

            return new T_Ciudadano()
            {
                idCiudadano = dto.idCiudadano,
                nombreUsuario = dto.nombreUsuario
            };
        }

        public DTO_Ciudadano toMap(T_Ciudadano ent)
        {
            if (ent == null)
                return null;

            return new DTO_Ciudadano()
            {
                idCiudadano = ent.idCiudadano,
                nombreUsuario = ent.nombreUsuario
            };
        }

        public List<T_Ciudadano> toEnt(List<DTO_Ciudadano> dto)
        {
            List<T_Ciudadano> toEnt = new List<T_Ciudadano>();
            foreach (DTO_Ciudadano item in dto)
            {
                toEnt.Add(this.toEnt(item));
            }
            return toEnt;
        }

        public List<DTO_Ciudadano> toMap(List<T_Ciudadano> ent)
        {
            List<DTO_Ciudadano> toMap = new List<DTO_Ciudadano>();
            foreach (T_Ciudadano item in ent)
            {
                toMap.Add(this.toMap(item));
            }
            return toMap;
        }
    }
}
