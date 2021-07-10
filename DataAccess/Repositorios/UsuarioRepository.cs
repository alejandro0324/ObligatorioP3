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

        public bool ExisteNombreUsuario(string nombreUsuario, string tipo)
        {
            bool existe = false;
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        existe = context.T_Usuario.AsNoTracking().Any(a => a.nombreUsuario == nombreUsuario && a.userType == tipo);
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return existe;
        }
        public string GetCorreoByUsuario (string nombreUsuario)
        {
            string correo = " ";
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        correo = context.T_Usuario.AsNoTracking().FirstOrDefault(a => a.nombreUsuario == nombreUsuario).correoElectronico;
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return correo;
        }
        public bool ValidarUsuario(DTO_Usuario dto)
        {
            bool existe = false;
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
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
        public bool ValidarUsuarioPublico(DTO_Usuario dto)
        {
            bool existe = false;
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        existe = context.T_Usuario.AsNoTracking().Any(a => a.nombreUsuario == dto.nombreUsuario && a.contraseña == dto.contraseña && a.userType == CGeneral.CLIENTE);
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
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
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
