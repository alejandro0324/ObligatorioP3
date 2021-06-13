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
    public class TipoReclamoRepository
    {
        private T_TipoReclamoMapper tipoReclamoMapper;
        public TipoReclamoRepository()
        {
            this.tipoReclamoMapper = new T_TipoReclamoMapper();
        }
        public List<DTO_TipoReclamo> ListarTipoReclamo()
        {
            List<DTO_TipoReclamo> TipoReclamo = new List<DTO_TipoReclamo>();
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        List<T_TipoReclamo> TipoReclamoDB = context.T_TipoReclamo.AsNoTracking().ToList();
                        TipoReclamo = this.tipoReclamoMapper.toMap(TipoReclamoDB);

                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return TipoReclamo;
        }
        public void AgregarTipoReclamo(DTO_TipoReclamo dto)
        {
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.T_TipoReclamo.Add(this.tipoReclamoMapper.toEnt(dto));

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
        public void ModificarTipoReclamo(DTO_TipoReclamo dto)
        {
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        T_TipoReclamo tipoReclamo = context.T_TipoReclamo.FirstOrDefault(f => f.Id == dto.id);
                        tipoReclamo.nombre = dto.nombre;
                        tipoReclamo.descripcion = dto.descripcion;

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
        public void BorrarTipoReclamo(int idTipoReclamo)
        {
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        T_TipoReclamo TipoReclamo = context.T_TipoReclamo.FirstOrDefault(f => f.Id == idTipoReclamo);
                        context.T_TipoReclamo.Remove(TipoReclamo);

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
