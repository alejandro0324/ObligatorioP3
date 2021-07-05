using BussinesLogic.Controllers;
using BussinesLogic.Logic;
using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.Controllers
{
    public class ReclamoInternoController : Controller
    {
        public ActionResult Listar()
        {
            LReclamoController reclamoController = new LReclamoController();
            LZonaController zonaController = new LZonaController();
            LCuadrillaController cuadrillaController = new LCuadrillaController();
            List<DTO_Reclamo> colDataModel = reclamoController.ListarReclamos();
            foreach (DTO_Reclamo item in colDataModel)
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
            colDataModel = colDataModel.OrderByDescending(g => g.situacion).ToList();
            return View(colDataModel);
        }

        public ActionResult Historial(int numero)
        {
            LLogReclamoController logReclamoController = new LLogReclamoController();
            List<DTO_LogReclamo> dto = logReclamoController.GetLogReclamosByNum(numero);
            return View(dto);
        }
        public ActionResult EditarCuadrilla(int numeroReclamo, int? numeroZona)
        {
            LReclamoController reclamoController = new LReclamoController();
            DTO_Reclamo dto = reclamoController.ReclamoByNumero(numeroReclamo);

            LCuadrillaController cuadrillaController = new LCuadrillaController();
            if (numeroZona == 0 || numeroZona == null)
            {
                ModelState.AddModelError("MsgReport", "No se pueden asignar cuadrillas sin antes asignar una zona");
                LZonaController zonaController = new LZonaController();
                List<DTO_Reclamo> colDataModel = reclamoController.ListarReclamos();
                foreach (DTO_Reclamo item in colDataModel)
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
                colDataModel = colDataModel.OrderByDescending(g => g.situacion).ToList();
                return View("Listar", colDataModel);
            }
            else
            {
                ViewBag.cuadrillas = cuadrillaController.ListarCuadrillasByNumZona((int)numeroZona).ToList();
                return View(dto);
            }
        }
        public ActionResult EditarCuadrillaSubmit(DTO_Reclamo dto)
        {
            LReclamoController reclamoController = new LReclamoController();
            reclamoController.ModificarReclamo(dto.cuadrilla, dto.numero);
            return RedirectToAction("Listar");
        }
    }
}