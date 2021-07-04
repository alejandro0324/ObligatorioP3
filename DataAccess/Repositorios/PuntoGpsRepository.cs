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
    public class PuntoGpsRepository
    {
        private T_PuntoGPSMapper puntoGPSMapper;
        public PuntoGpsRepository()
        {
            this.puntoGPSMapper = new T_PuntoGPSMapper();
        }
        public DTO_PuntoGPS AgregarPuntoGps(DTO_PuntoGPS dto)
        {
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.T_PuntoGps.Add(this.puntoGPSMapper.toEnt(dto));

                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return dto;
        }
        public void ModificarPuntoGps(DTO_PuntoGPS dto)
        {
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        T_PuntoGps puntoGpsModificado = context.T_PuntoGps.FirstOrDefault(f => f.id == dto.id);
                        puntoGpsModificado.latitud = dto.latitud;
                        puntoGpsModificado.longitud = dto.longitud;

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
        public void BorrarPuntoGps(int id)
        {
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        T_PuntoGps puntoGps = context.T_PuntoGps.FirstOrDefault(f => f.id == id);
                        context.T_PuntoGps.Remove(puntoGps);

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
