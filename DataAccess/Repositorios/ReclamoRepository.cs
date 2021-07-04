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
    public class ReclamoRepository
    {
        private T_ReclamoMapper reclamoMapper;
        public ReclamoRepository()
        {
            this.reclamoMapper = new T_ReclamoMapper();
        }
        public List<DTO_Reclamo> ListarReclamosPersonales()
        {
            List<DTO_Reclamo> Reclamos = new List<DTO_Reclamo>();
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        List<T_Reclamo> ReclamoDB = context.T_Reclamo.Where(w => w.situacion == CGeneral.ACTIVO).AsNoTracking().ToList();
                        Reclamos = this.reclamoMapper.toMap(ReclamoDB);

                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return Reclamos;
        }
        public void ModificarReclamo(DTO_Reclamo dto)
        {
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        T_Reclamo reclamo = context.T_Reclamo.FirstOrDefault(f => f.numero == dto.numero);
                        reclamo.estado = dto.estado;
                        reclamo.numeroZona = dto.numeroZona;
                        reclamo.numeroCuadrilla = dto.numeroCuadrilla;
                        reclamo.comentarioFuncionario = dto.comentarioFuncionario;

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
        public DTO_Reclamo AgregarReclamo(DTO_Reclamo dto)
        {
            DTO_Reclamo dtoReturn = dto;
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        T_Reclamo reclamoNuevo = new T_Reclamo();
                        reclamoNuevo = this.reclamoMapper.toEnt(dto);
                        context.T_Reclamo.Add(reclamoNuevo);
                        context.SaveChanges();
                        trann.Commit();
                        dtoReturn.numero = reclamoNuevo.numero;
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return dtoReturn;
        }
        public void BorrarReclamo(int numReclamo)
        {
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        T_Reclamo reclamo = context.T_Reclamo.FirstOrDefault(f => f.numero == numReclamo);
                        reclamo.situacion = CGeneral.INACTIVO;
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
        public DTO_Reclamo ReclamoByNumero(int numero)
        {
            DTO_Reclamo dto = new DTO_Reclamo();
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        return this.reclamoMapper.toMap(context.T_Reclamo.AsNoTracking().FirstOrDefault(f => f.numero == numero));
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return dto;
        }
    }
}
