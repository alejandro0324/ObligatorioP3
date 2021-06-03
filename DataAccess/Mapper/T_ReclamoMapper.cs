using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class T_ReclamoMapper
    {
        public T_Reclamo toEnt(DTO_Reclamo dto)
        {
            if (dto == null)
                return null;

            return new T_Reclamo()
            {
                IdCiudadano = dto.idCiudadano,
                longitud = dto.longitud,
                latitud = dto.latitud,
                comentarioFuncionario = dto.comentarioFuncionario,
                estado = dto.estado,
                fechahora = dto.fchaHora,
                numero = dto.numero,
                IdTipoReclamo = dto.idTipoReclamo, 
                numeroCuadrilla = dto.numeroCuadrilla,
                numeroZona = dto.numeroZona,
                observacionesCiudadano = dto.observacionesCiudadano,
                observacionesCuadrilla = dto.observacionesCuadrilla,
            };
        }

        public DTO_Reclamo toMap(T_Reclamo ent)
        {
            if (ent == null)
                return null;

            return new DTO_Reclamo()
            {
                idCiudadano = ent.IdCiudadano,
                longitud = ent.longitud,
                latitud = ent.latitud,
                comentarioFuncionario = ent.comentarioFuncionario,
                estado = ent.estado,
                fchaHora = ent.fechahora,
                numero = ent.numero,
                idTipoReclamo = ent.IdTipoReclamo,
                numeroCuadrilla = ent.numeroCuadrilla,
                numeroZona = ent.numeroZona,
                observacionesCiudadano = ent.observacionesCiudadano,
                observacionesCuadrilla = ent.observacionesCuadrilla,
            };
        }

        public List<T_Reclamo> toEnt(List<DTO_Reclamo> dto)
        {
            List<T_Reclamo> toEnt = new List<T_Reclamo>();
            foreach (DTO_Reclamo item in dto)
            {
                toEnt.Add(this.toEnt(item));
            }
            return toEnt;
        }

        public List<DTO_Reclamo> toMap(List<T_Reclamo> ent)
        {
            List<DTO_Reclamo> toMap = new List<DTO_Reclamo>();
            foreach (T_Reclamo item in ent)
            {
                toMap.Add(this.toMap(item));
            }
            return toMap;
        }
    }
}
