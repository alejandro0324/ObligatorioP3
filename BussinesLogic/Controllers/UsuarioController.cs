using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controllers
{
    public class UsuarioController
    {
        private Repository repository;

        public UsuarioController()
        {
            this.repository = new Repository();
        }
    }
}
