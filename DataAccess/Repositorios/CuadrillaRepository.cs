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
    public class CuadrillaRepository
    {
        private T_CuadrillaMapper cuadrillaMapper;
        public CuadrillaRepository()
        {
            this.cuadrillaMapper = new T_CuadrillaMapper();
        }
        public void ActivarCuadrilla(int numCuadrilla)
        {
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.T_Cuadrilla.FirstOrDefault(f => f.numero == numCuadrilla).situacion = CGeneral.ACTIVO;
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
        public bool ContieneReclamos(DTO_Cuadrilla dto)
        {
            bool existe = false;
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        existe = context.T_Reclamo.AsNoTracking().Any(a => a.numeroCuadrilla == dto.numero && a.situacion == CGeneral.ACTIVO);
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return existe;
        }
        public List<DTO_Cuadrilla> ListarCuadrillas()
        {
            List<DTO_Cuadrilla> Cuadrillas = new List<DTO_Cuadrilla>();
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        List<T_Cuadrilla> CuadrillaDB = context.T_Cuadrilla.AsNoTracking().ToList();
                        Cuadrillas = this.cuadrillaMapper.toMap(CuadrillaDB);

                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return Cuadrillas;
        }
        public List<DTO_Cuadrilla> ListarCuadrillasByNumZona(int numero)
        {
            List<DTO_Cuadrilla> Cuadrillas = new List<DTO_Cuadrilla>();
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        List<T_Cuadrilla> CuadrillaDB = context.T_Cuadrilla.Where(w => w.numZona == numero).AsNoTracking().ToList();
                        Cuadrillas = this.cuadrillaMapper.toMap(CuadrillaDB);

                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return Cuadrillas;
        }
        public void AgregarCuadrilla(DTO_Cuadrilla dto)
        {
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.T_Cuadrilla.Add(this.cuadrillaMapper.toEnt(dto));

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
        public void ModificarCuadrilla(DTO_Cuadrilla dto)
        {
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        T_Cuadrilla cuadrillaModificada = context.T_Cuadrilla.FirstOrDefault(f => f.numero == dto.numero);
                        cuadrillaModificada.nombre = dto.nombre;
                        cuadrillaModificada.cantidadPeones = dto.cantidadPeones;
                        cuadrillaModificada.numZona = dto.numZona;

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
        public bool ExisteCuadrilla(int numCuadrilla)
        {
            bool existe = false;
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        existe = context.T_Cuadrilla.AsNoTracking().Any(a => a.numero == numCuadrilla);
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return existe;
        }
        public void BorrarCuadrilla(int numCuadrilla)
        {
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.T_Cuadrilla.FirstOrDefault(f => f.numero == numCuadrilla).situacion = CGeneral.INACTIVO;
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
        public DTO_Cuadrilla CuadrillaByNumero(int numero)
        {
            DTO_Cuadrilla dto = new DTO_Cuadrilla();
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        dto = this.cuadrillaMapper.toMap(context.T_Cuadrilla.AsNoTracking().FirstOrDefault(f => f.numero == numero));
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
