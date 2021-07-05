using CommonSolution.Constantes;
using CommonSolution.DTOs;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Logic
{
    public class LUsuarioController
    {
        private Repository repository;

        public LUsuarioController()
        {
            this.repository = new Repository();
        }

        public bool ExisteNombreUsuario(string nombreUsuario)
        {
            return this.repository.GetUsuarioRepository().ExisteNombreUsuario(nombreUsuario);
        }

        public bool ValidarUsuario(DTO_Usuario dto)
        {
            return this.repository.GetUsuarioRepository().ValidarUsuario(dto);
        }

        public void RegistrarUsuario(DTO_Usuario dto, string tipo)
        {
            if (tipo == "0")
            {
                dto.userType = CGeneral.FUNCIONARIO;
            }
            else
            {
                dto.userType = CGeneral.CLIENTE;
            }
            
            this.repository.GetUsuarioRepository().RegistrarUsuario(dto);
        }
    }
}
