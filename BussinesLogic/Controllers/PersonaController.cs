﻿using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controllers
{
    public class PersonaController
    {
        private Repository repository;

        public PersonaController()
        {
            this.repository = new Repository();
        }
    }
}
