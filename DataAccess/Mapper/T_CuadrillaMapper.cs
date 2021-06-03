﻿using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class T_CuadrillaMapper
    {
        public T_Cuadrilla toEnt(DTO_Cuadrilla dto)
        {
            if (dto == null)
                return null;

            return new T_Cuadrilla()
            {
                cantidadPeones = dto.cantidadPeones,
                IdFuncionario = dto.idFuncionario,
                nombre = dto.nombre,
                numero = dto.numero
            };
        }

        public DTO_Cuadrilla toMap(T_Cuadrilla ent)
        {
            if (ent == null)
                return null;

            return new DTO_Cuadrilla()
            {
                cantidadPeones = ent.cantidadPeones,
                idFuncionario = ent.IdFuncionario,
                nombre = ent.nombre,
                numero = ent.numero
            };
        }

        public List<T_Cuadrilla> toEnt(List<DTO_Cuadrilla> dto)
        {
            List<T_Cuadrilla> toEnt = new List<T_Cuadrilla>();
            foreach (DTO_Cuadrilla item in dto)
            {
                toEnt.Add(this.toEnt(item));
            }
            return toEnt;
        }

        public List<DTO_Cuadrilla> toMap(List<T_Cuadrilla> ent)
        {
            List<DTO_Cuadrilla> toMap = new List<DTO_Cuadrilla>();
            foreach (T_Cuadrilla item in ent)
            {
                toMap.Add(this.toMap(item));
            }
            return toMap;
        }
    }
}
