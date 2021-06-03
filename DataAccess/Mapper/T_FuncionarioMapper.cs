using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class T_FuncionarioMapper
    {
        public T_Funcionario toEnt(DTO_Funcionario dto)
        {
            if (dto == null)
                return null;

            return new T_Funcionario()
            {
                idFuncionario = dto.idFuncionario,
                nombreUsuario = dto.nombreUsuario
            };
        }

        public DTO_Funcionario toMap(T_Funcionario ent)
        {
            if (ent == null)
                return null;

            return new DTO_Funcionario()
            {
                idFuncionario = ent.idFuncionario,
                nombreUsuario = ent.nombreUsuario
            };
        }

        public List<T_Funcionario> toEnt(List<DTO_Funcionario> dto)
        {
            List<T_Funcionario> toEnt = new List<T_Funcionario>();
            foreach (DTO_Funcionario item in dto)
            {
                toEnt.Add(this.toEnt(item));
            }
            return toEnt;
        }

        public List<DTO_Funcionario> toMap(List<T_Funcionario> ent)
        {
            List<DTO_Funcionario> toMap = new List<DTO_Funcionario>();
            foreach (T_Funcionario item in ent)
            {
                toMap.Add(this.toMap(item));
            }
            return toMap;
        }
    }
}
