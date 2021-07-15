using BussinesLogic.Controllers;
using BussinesLogic.Logic;
using CommonSolution.Constantes;
using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebInterna.Helpers;

namespace WebInterna.Controllers
{
    [UserAuthentication]
    public class ReporteController : Controller
    {
        public ActionResult Listar()
        {
            return View();
        }

        public ActionResult PrimerReporte()
        {
            LCuadrillaController cuadrillaController = new LCuadrillaController();
            ViewBag.cuadrillas = cuadrillaController.ListarCuadrillas();
            List<DTO_Reclamo> lista = new List<DTO_Reclamo>();
            return View(lista);
        }

        public ActionResult PrimerReporteSubmit(DTO_Reclamo dto)
        {
            List<DTO_Reclamo> lista = new List<DTO_Reclamo>();
            LCuadrillaController cuadrillaController = new LCuadrillaController();
            LReclamoController reclamoController = new LReclamoController();
            LZonaController zonaController = new LZonaController();
            lista = cuadrillaController.GetReclamos(dto.numero);
            foreach (DTO_Reclamo item in lista)
            {
                item.tipoReclamo = reclamoController.tipoReclamoById((int)item.idTipoReclamo);
                if (item.numeroZona != null)
                {
                    item.zona = zonaController.ZonaByNumero((int)item.numeroZona);
                }
                if (item.numeroCuadrilla != null)
                {
                    item.cuadrilla = cuadrillaController.CuadrillaByNumero((int)item.numeroCuadrilla);
                }
            }
            return PartialView("_ListarReclamos", lista);
        }

        public ActionResult SegundoReporte()
        {
            List<DTO_Reclamo> lista = new List<DTO_Reclamo>();
            LReclamoController reclamoController = new LReclamoController();
            LZonaController zonaController = new LZonaController();
            LCuadrillaController cuadrillaController = new LCuadrillaController();
            lista = reclamoController.ReclamosAtrasados();
            foreach (DTO_Reclamo item in lista)
            {
                item.tipoReclamo = reclamoController.tipoReclamoById((int)item.idTipoReclamo);
                if (item.numeroZona != null)
                {
                    item.zona = zonaController.ZonaByNumero((int)item.numeroZona);
                }
                if (item.numeroCuadrilla != null)
                {
                    item.cuadrilla = cuadrillaController.CuadrillaByNumero((int)item.numeroCuadrilla);
                }
            }
            return View(lista);
        }
        public ActionResult TercerReporte()
        {
            List<DTO_Cuadrilla> lista = new List<DTO_Cuadrilla>();
            LCuadrillaController cuadrillaController = new LCuadrillaController();
            lista = cuadrillaController.ListarCuadrillas();
            foreach (var item in lista)
            {
                item.promedio = cuadrillaController.CalcularPromedio(item.numero);
            }
            lista.OrderBy(o => o.promedio);
            return View(lista);
        }
        public ActionResult CuartoReporte()
        {
            LReclamoController reclamoController = new LReclamoController();
            List<DTO_Reclamo> lista = reclamoController.ReclamosAtrasados();
            return View(lista);
        }

        public ActionResult QuintoReporte()
        {
            return View();
        }
        public ActionResult QuintoReporteSubmit(string valorFechaUno, string valorFechaDos)
        {
            List<DTO_LogReclamo> lista = new List<DTO_LogReclamo>();
            LLogReclamoController reclamoController = new LLogReclamoController();
            if (valorFechaUno != "" && valorFechaDos != "")
            {
                DateTime fechaUno = DateTime.Parse(valorFechaUno);
                DateTime fechaDos = DateTime.Parse(valorFechaDos);
                lista = reclamoController.ListarReclamosPorFechas(fechaUno, fechaDos);
                return PartialView("_MapaTermico", lista);
            }
            else
            {
                return PartialView("_MapaTermico", lista);
            }
        }

    }
}