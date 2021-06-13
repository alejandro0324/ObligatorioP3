﻿using CommonSolution;
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
        public List<DTO_Cuadrilla> ListarCuadrillas()
        {
            List<DTO_Cuadrilla> Cuadrillas = new List<DTO_Cuadrilla>();
            using (ATEntities context = new ATEntities())
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
        public void AgregarCuadrilla(DTO_Cuadrilla dto)
        {
            using (ATEntities context = new ATEntities())
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
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        T_Cuadrilla cuadrillaModificada = context.T_Cuadrilla.FirstOrDefault(f => f.numero == dto.numero);
                        cuadrillaModificada.nombre = dto.nombre;
                        cuadrillaModificada.cantidadPeones = dto.cantidadPeones;

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
        public void BorrarCuadrilla(int numCuadrilla)
        {
            using (ATEntities context = new ATEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        T_Cuadrilla Cuadrilla = context.T_Cuadrilla.FirstOrDefault(f => f.numero == numCuadrilla);
                        context.T_Cuadrilla.Remove(Cuadrilla);

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
