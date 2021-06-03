using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class T_PersonaMapper
    {
        public T_Persona toEnt(DTO_Persona dto)
        {
            if (dto == null)
                return null;

            return new T_Persona()
            {
                apellido = dto.apellido,
                nombreUsuario = dto.nombreUsuario,
                contraseña = dto.contraseña,
                correoElectronico = dto.correoElectronico,
                nombre = dto.nombre,
                telefono = dto.telefono
            };
        }

        public DTO_Persona toMap(T_Persona ent)
        {
            if (ent == null)
                return null;

            return new DTO_Persona()
            {
                apellido = ent.apellido,
                nombreUsuario = ent.nombreUsuario,
                contraseña = ent.contraseña,
                correoElectronico = ent.correoElectronico,
                nombre = ent.nombre,
                telefono = ent.telefono
            };
        }

        public List<T_Persona> toEnt(List<DTO_Persona> dto)
        {
            List<T_Persona> toEnt = new List<T_Persona>();
            foreach (DTO_Persona item in dto)
            {
                toEnt.Add(this.toEnt(item));
            }
            return toEnt;
        }

        public List<DTO_Persona> toMap(List<T_Persona> ent)
        {
            List<DTO_Persona> toMap = new List<DTO_Persona>();
            foreach (T_Persona item in ent)
            {
                toMap.Add(this.toMap(item));
            }
            return toMap;
        }

    }
}
