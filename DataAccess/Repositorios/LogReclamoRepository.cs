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
    }
}
