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
    public class ZonaRepository
    {
        private T_ZonaMapper zonaMapper;
        public ZonaRepository()
        {
            this.zonaMapper = new T_ZonaMapper();
        }

        public bool ContieneReclamos(DTO_Zona dto)
        {
            bool existe = false;
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        existe = context.T_Reclamo.AsNoTracking().Any(a => a.numeroZona == dto.numero);
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return existe;
        }
        public DTO_Zona ZonaByNumero(int numero)
        {
            DTO_Zona dto = new DTO_Zona();
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        dto = this.zonaMapper.toMap(context.T_Zona.Include("T_Cuadrilla").AsNoTracking().FirstOrDefault(a => a.numero == numero));
                        
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return dto;
        }
        public bool ExisteZona(int numero)
        {
            bool existe = false;
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        existe = context.T_Zona.AsNoTracking().Any(a => a.numero == numero);
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return existe;
        }
        public void AgregarZona(DTO_Zona dto)
        {
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.T_Zona.Add(this.zonaMapper.toEnt(dto));

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
        public void BorrarZona(int numZona)
        {
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.T_Zona.FirstOrDefault(f => f.numero == numZona).situacion = CGeneral.INACTIVO;
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
        public void ActivarZona(int numZona)
        {
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.T_Zona.FirstOrDefault(f => f.numero == numZona).situacion = CGeneral.ACTIVO;
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
        public List<DTO_Zona> ListarZonas()
        {
            List<DTO_Zona> Zonas = new List<DTO_Zona>();
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        List<T_Zona> ZonasDB = context.T_Zona.AsNoTracking().ToList();
                        Zonas = this.zonaMapper.toMap(ZonasDB);
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return Zonas;
        }
        public List<DTO_Zona> ListarZonasActivas()
        {
            List<DTO_Zona> Zonas = new List<DTO_Zona>();
            using (AyuntamientoToledoEntities context = new AyuntamientoToledoEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        List<T_Zona> ZonasDB = context.T_Zona.Where(w => w.situacion == CGeneral.ACTIVO).AsNoTracking().ToList();
                        Zonas = this.zonaMapper.toMap(ZonasDB);

                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return Zonas;
        }
    }
}
