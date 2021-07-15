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
        private T_CuadrillaMapper cuadrillaMapper;
        public ReclamoRepository()
        {
            this.reclamoMapper = new T_ReclamoMapper();
        }
        public List<DTO_Reclamo> ListarReclamosPersonales(string nombre)
        {
            List<DTO_Reclamo> Reclamos = new List<DTO_Reclamo>();
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        List<T_Reclamo> ReclamoDB = context.T_Reclamo.Where(w => w.nombreCliente == nombre).AsNoTracking().ToList();
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
        public void ModificarEstado(DTO_Reclamo dto)
        {
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        T_Reclamo t = context.T_Reclamo.FirstOrDefault(f => f.numero == dto.numero);
                        t.nombreFuncionario = dto.nombreFuncionario;
                        t.estado = dto.estado;
                        t.comentarioFuncionario = dto.comentarioFuncionario;
                        t.situacion = dto.situacion;
                        t.fechahora = dto.fchaHora;
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
        public void ModificarCuadrilla(int numero, int? numeroCuadrilla)
        {
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.T_Reclamo.FirstOrDefault(f => f.numero == numero).numeroCuadrilla = numeroCuadrilla;
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
        public void DesestimarReclamo(DTO_Reclamo dto)
        {
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        T_Reclamo t = context.T_Reclamo.FirstOrDefault(f => f.numero == dto.numero);
                        t.comentarioFuncionario = dto.comentarioFuncionario;
                        t.estado = dto.estado;
                        t.situacion = dto.situacion;
                        t.fechahora = dto.fchaHora;
                        t.nombreFuncionario = dto.nombreFuncionario;
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
        public List<DTO_Reclamo> ListarReclamos()
        {
            List<DTO_Reclamo> Reclamos = new List<DTO_Reclamo>();
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
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
        public List<DTO_Reclamo> ListarReclamos(string estado)
        {
            List<DTO_Reclamo> Reclamos = new List<DTO_Reclamo>();
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        List<T_Reclamo> ReclamoDB = context.T_Reclamo.AsNoTracking().Where(w => w.estado.Contains(estado)).Select(s => s).ToList();
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
        public List<DTO_Reclamo> ListarReclamosActivos()
        {
            List<DTO_Reclamo> Reclamos = new List<DTO_Reclamo>();
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
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
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
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
        public void ModificarReclamo(DTO_Cuadrilla dto, int numeroReclamo)
        {
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        T_Reclamo reclamo = context.T_Reclamo.FirstOrDefault(f => f.numero == numeroReclamo);
                        reclamo.numeroZona = dto.numZona;
                        reclamo.T_Cuadrilla = this.cuadrillaMapper.toEnt(dto);

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
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
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
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        T_Reclamo reclamo = context.T_Reclamo.FirstOrDefault(f => f.numero == numReclamo);
                        reclamo.estado = "DESESTIMADO";
                        reclamo.situacion = CGeneral.INACTIVO;
                        reclamo.fechahora = DateTime.Now;
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
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
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
        public List<DTO_Reclamo> ListarReclamosByCuadrilla(int numero)
        {
            List<DTO_Reclamo> dto = new List<DTO_Reclamo>();
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        dto = this.reclamoMapper.toMap(context.T_Reclamo.AsNoTracking().Where(w => w.numeroCuadrilla == numero).ToList());
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return dto;
        }
        public List<DTO_Reclamo> ListarReclamosFinalizadosByCuadrilla(int numero)
        {
            List<DTO_Reclamo> dto = new List<DTO_Reclamo>();
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        dto = this.reclamoMapper.toMap(context.T_Reclamo.AsNoTracking().Where(w => w.numeroCuadrilla == numero && w.estado == CGeneral.RESUELTO).ToList());
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return dto;
        }
        public List<DTO_Reclamo> ReclamosAtrasados()
        {
            List<DTO_Reclamo> dto = new List<DTO_Reclamo>();
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        dto = this.reclamoMapper.toMap(context.T_Reclamo.AsNoTracking().Where(w => w.estado != CGeneral.DESESTIMADO && w.estado != CGeneral.RESUELTO).ToList());
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
