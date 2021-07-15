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
    public class LogReclamoRepository
    {
        private T_LogReclamoMapper logReclamoMapper;
        public LogReclamoRepository()
        {
            this.logReclamoMapper = new T_LogReclamoMapper();
        }

        public List<DTO_LogReclamo> GetLogReclamosByNum(int numero)
        {
            List<DTO_LogReclamo> Reclamos = new List<DTO_LogReclamo>();
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        return this.logReclamoMapper.toMap(context.T_LogReclamo.AsNoTracking().Where(w => w.numReclamo == numero).ToList());
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return Reclamos;
        }
        public List<DTO_LogReclamo> ListarReclamosPorFechas(DateTime fechaUno, DateTime fechaDos)
        {
            List<DTO_LogReclamo> dto = new List<DTO_LogReclamo>();
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        dto = this.logReclamoMapper.toMap(context.T_LogReclamo.AsNoTracking()
                            .Where(w => w.fechaHora.Value.Month >= fechaUno.Month &&
                                        w.fechaHora.Value.Day >= fechaUno.Day &&
                                        w.fechaHora.Value.Year >= fechaUno.Year && 
                                        w.fechaHora.Value.Month <= fechaDos.Month &&
                                        w.fechaHora.Value.Day <= fechaDos.Day &&
                                        w.fechaHora.Value.Year <= fechaDos.Year
                                        && w.estado == CGeneral.PENDIENTE).ToList());
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return dto;
        }
        public List<DTO_LogReclamo> ListarReclamosActivos()
        {
            List<DTO_LogReclamo> dto = new List<DTO_LogReclamo>();
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        dto = this.logReclamoMapper.toMap(context.T_LogReclamo.AsNoTracking().Where(w => w.estado == CGeneral.PENDIENTE).ToList());
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return dto;
        }

        public DateTime TiempoInicialDelReclamo(int numeroReclamo)
        {
            DateTime tiempo = new DateTime();
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        tiempo = (DateTime)context.T_LogReclamo.FirstOrDefault(f => f.estado == CGeneral.PENDIENTE && f.numReclamo == numeroReclamo).fechaHora;
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return tiempo;
        }

        public double TiempoDeFinalizaciónPromedio(int numero)
        {
            double promedio = 0;
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        TimeSpan? aux = context.T_LogReclamo.AsNoTracking().FirstOrDefault(f => f.numReclamo == numero && f.estado == CGeneral.RESUELTO).fechaHora - context.T_LogReclamo.AsNoTracking().FirstOrDefault(f => f.numReclamo == numero && f.estado == CGeneral.PENDIENTE).fechaHora;
                        promedio = aux.Value.TotalHours;
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return promedio;
        }
    }
}
