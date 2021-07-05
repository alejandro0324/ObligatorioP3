using CommonSolution;
using CommonSolution.Constantes;
using CommonSolution.DTOs;
using DataAccess.Mapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorios
{
    public class UsuarioRepository
    {
        private T_UsuarioMapper UsuarioMapper;
        public UsuarioRepository()
        {
            this.UsuarioMapper = new T_UsuarioMapper();
        }

        public bool ExisteNombreUsuario(string nombreUsuario)
        {
            bool existe = false;
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        existe = context.T_Usuario.AsNoTracking().Any(a => a.nombreUsuario == nombreUsuario && a.userType == CGeneral.FUNCIONARIO);
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return existe;
        }

        public bool ValidarUsuario(DTO_Usuario dto)
        {
            bool existe = false;
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        existe = context.T_Usuario.AsNoTracking().Any(a => a.nombreUsuario == dto.nombreUsuario && a.contraseña == dto.contraseña && a.userType == CGeneral.FUNCIONARIO);
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return existe;
        }

        public void RegistrarUsuario(DTO_Usuario dto)
        {
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.T_Usuario.Add(this.UsuarioMapper.toEnt(dto));
                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
        }

    }
}
