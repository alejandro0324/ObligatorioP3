using DataAccess.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistencia
{
    public class Repository
    {
        private UsuarioRepository personaRepository;

        public Repository()
        {
            this.personaRepository = new UsuarioRepository();
        }
        
        public UsuarioRepository GetPersonaRepository()
        {
            return this.personaRepository;
        }
    }
}
