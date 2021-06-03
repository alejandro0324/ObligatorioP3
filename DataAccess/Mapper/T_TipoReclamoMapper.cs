using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class T_TipoReclamoMapper
    {
        public T_TipoReclamo toEnt(DTO_TipoReclamo dto)
        {
            if (dto == null)
                return null;

            return new T_TipoReclamo()
            {
                descripcion = dto.descripcion,
                Id = dto.id,
                nombre = dto.nombre
            };
        }

        public DTO_TipoReclamo toMap(T_TipoReclamo ent)
        {
            if (ent == null)
                return null;

            return new DTO_TipoReclamo()
            {
                descripcion = ent.descripcion,
                id = ent.Id,
                nombre = ent.nombre
            };
        }

        public List<T_TipoReclamo> toEnt(List<DTO_TipoReclamo> dto)
        {
            List<T_TipoReclamo> toEnt = new List<T_TipoReclamo>();
            foreach (DTO_TipoReclamo item in dto)
            {
                toEnt.Add(this.toEnt(item));
            }
            return toEnt;
        }

        public List<DTO_TipoReclamo> toMap(List<T_TipoReclamo> ent)
        {
            List<DTO_TipoReclamo> toMap = new List<DTO_TipoReclamo>();
            foreach (T_TipoReclamo item in ent)
            {
                toMap.Add(this.toMap(item));
            }
            return toMap;
        }
    }
}
