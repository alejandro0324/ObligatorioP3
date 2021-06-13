using CommonSolution;
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
        public List<DTO_Reclamo> ListarReclamo()
        {
            List<DTO_Reclamo> Reclamos = new List<DTO_Reclamo>();
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        List<T_Reclamo> ReclamoDB = context.T_Reclamo.AsNoTracking().ToList();
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
        public void AgregarReclamo(DTO_Reclamo dto)
        {
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.T_Reclamo.Add(this.reclamoMapper.toEnt(dto));

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
        public void BorrarReclamo(int numReclamo)
        {
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        T_Reclamo reclamo = context.T_Reclamo.FirstOrDefault(f => f.numero == numReclamo);
                        context.T_Reclamo.Remove(reclamo);

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
