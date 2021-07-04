using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class T_LogReclamoMapper
    {
        public T_LogReclamo toEnt(DTO_LogReclamo dto)
        {
            if (dto == null)
                return null;

            return new T_LogReclamo()
            {
                comentarioFuncionario = dto.comentarioFuncionario,
                estado = dto.estado,
                fechaHora = dto.fechaHora,
                latitud = dto.latitud,
                longitud = dto.longitud,
                nombreUsuario = dto.nombreUsuario,
                numReclamo = dto.numReclamo,
                observacionesCiudadno = dto.observacionesCiudadano,
                observacionesCuadrilla = dto.observacionesCuadrilla,
                tipoReclamo = dto.tipoReclamo  
            };
        }

        public DTO_LogReclamo toMap(T_LogReclamo ent)
        {
            if (ent == null)
                return null;

            return new DTO_LogReclamo()
            {
                comentarioFuncionario = ent.comentarioFuncionario,
                estado = ent.estado,
                fechaHora = ent.fechaHora,
                latitud = ent.latitud,
                longitud = ent.longitud,
                nombreUsuario = ent.nombreUsuario,
                numReclamo = ent.numReclamo,
                observacionesCiudadano = ent.observacionesCiudadno,
                observacionesCuadrilla = ent.observacionesCuadrilla,
                tipoReclamo = ent.tipoReclamo
            };
        }

        public List<T_LogReclamo> toEnt(List<DTO_LogReclamo> dto)
        {
            List<T_LogReclamo> toEnt = new List<T_LogReclamo>();
            foreach (DTO_LogReclamo item in dto)
            {
                toEnt.Add(this.toEnt(item));
            }
            return toEnt;
        }

        public List<DTO_LogReclamo> toMap(List<T_LogReclamo> ent)
        {
            List<DTO_LogReclamo> toMap = new List<DTO_LogReclamo>();
            foreach (T_LogReclamo item in ent)
            {
                toMap.Add(this.toMap(item));
            }
            return toMap;
        }
    }
}
