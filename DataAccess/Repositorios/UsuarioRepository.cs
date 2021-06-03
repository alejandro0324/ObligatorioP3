using DataAccess.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorios
{
    public class UsuarioRepository
    {
        private T_UsuarioMapper personaMapper;

        public UsuarioRepository()
        {
            this.personaMapper = new T_UsuarioMapper();
        }


    }
}
