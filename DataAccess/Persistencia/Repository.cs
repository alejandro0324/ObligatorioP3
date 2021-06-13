using DataAccess.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistencia
{
    public class Repository
    {
        private ZonaRepository zonaRepository;
        private CuadrillaRepository cuadrillaRepository;
        private TipoReclamoRepository tipoReclamoRepository;
        private ReclamoRepository reclamoRepository;
        private PuntoGpsRepository puntoGpsRepository;

        public Repository()
        {
            this.zonaRepository = new ZonaRepository();
            this.cuadrillaRepository = new CuadrillaRepository();
            this.tipoReclamoRepository = new TipoReclamoRepository();
            this.reclamoRepository = new ReclamoRepository();
            this.puntoGpsRepository = new PuntoGpsRepository();
        }
        
        public ZonaRepository GetZonaRepository()
        {
            return this.zonaRepository;
        }
        public CuadrillaRepository GetCuadrillaRepository()
        {
            return this.cuadrillaRepository;
        }
        public TipoReclamoRepository GetTipoReclamoRepository()
        {
            return this.tipoReclamoRepository;
        }
        public ReclamoRepository GetReclamoRepository()
        {
            return this.reclamoRepository;
        }
        public PuntoGpsRepository GetPuntoGpsRepository()
        {
            return this.puntoGpsRepository;
        }
    }
}
