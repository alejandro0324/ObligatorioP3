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
    public class ZonaRepository
    {
        private T_ZonaMapper zonaMapper;
        public ZonaRepository()
        {
            this.zonaMapper = new T_ZonaMapper();
        }

        public void AgregarZona(DTO_Zona dto)
        {
            using (ATEntities context = new ATEntities())
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
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        T_Zona Zona = context.T_Zona.FirstOrDefault(f => f.numero == numZona);
                        context.T_Zona.Remove(Zona);

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
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        List<T_Zona> ZonasDB = context.T_Zona.AsNoTracking().ToList();
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
