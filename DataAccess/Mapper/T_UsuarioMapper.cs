using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class T_UsuarioMapper
    {
        public T_Usuario toEnt(DTO_Usuario dto)
        {
            if (dto == null)
                return null;

            return new T_Usuario()
            {
                apellido = dto.apellido,
                nombreUsuario = dto.nombreUsuario,
                contraseña = dto.contraseña,
                correoElectronico = dto.correoElectronico,
                nombre = dto.nombre,
                telefono = dto.telefono
            };
        }

        public DTO_Usuario toMap(T_Usuario ent)
        {
            if (ent == null)
                return null;

            return new DTO_Usuario()
            {
                apellido = ent.apellido,
                nombreUsuario = ent.nombreUsuario,
                contraseña = ent.contraseña,
                correoElectronico = ent.correoElectronico,
                nombre = ent.nombre,
                telefono = ent.telefono
            };
        }

        public List<T_Usuario> toEnt(List<DTO_Usuario> dto)
        {
            List<T_Usuario> toEnt = new List<T_Usuario>();
            foreach (DTO_Usuario item in dto)
            {
                toEnt.Add(this.toEnt(item));
            }
            return toEnt;
        }

        public List<DTO_Usuario> toMap(List<T_Usuario> ent)
        {
            List<DTO_Usuario> toMap = new List<DTO_Usuario>();
            foreach (T_Usuario item in ent)
            {
                toMap.Add(this.toMap(item));
            }
            return toMap;
        }

    }
}
