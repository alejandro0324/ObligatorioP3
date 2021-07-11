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
        public ActionResult EditarEstado(int numeroReclamo)
        {
            LReclamoController reclamoController = new LReclamoController();
            DTO_Reclamo dto = reclamoController.ReclamoByNumero(numeroReclamo);
            ViewBag.siguiente = reclamoController.SiguienteEstado(dto);
            return View(dto);
        }
        public ActionResult EditarEstadoSubmit(DTO_Reclamo dto, int numero)
        {
            LReclamoController reclamoController = new LReclamoController();
            DTO_Reclamo dtoAux = reclamoController.ReclamoByNumero(numero);
            dtoAux.fchaHora = DateTime.Now;
            dtoAux.comentarioFuncionario = dto.comentarioFuncionario;
            dtoAux.estado = reclamoController.SiguienteEstado(dtoAux);
            string nombreUsuario = Session["nombreUsuario"].ToString();
            dtoAux.nombreFuncionario = nombreUsuario;
            reclamoController.ModificarEstado(dtoAux);
            return RedirectToAction("Listar");
        }

        public ActionResult Desestimar(int numero)
        {
            LReclamoController reclamoController = new LReclamoController();
            DTO_Reclamo dto = reclamoController.ReclamoByNumero(numero);
            return View(dto);
        }
        public ActionResult DesestimarSubmit(DTO_Reclamo dto)
        {
            LReclamoController reclamoController = new LReclamoController();
            DTO_Reclamo dtoAux = reclamoController.ReclamoByNumero(dto.numero);
            dtoAux.comentarioFuncionario = dto.comentarioFuncionario;
            dtoAux.nombreFuncionario = Session["nombreUsuario"].ToString();
            dtoAux.fchaHora = DateTime.Now;
            dtoAux.situacion = CGeneral.INACTIVO;
            dtoAux.estado = "DESESTIMADO";
            reclamoController.DesestimarReclamo(dtoAux);
            return RedirectToAction("Listar");
        }

        public ActionResult AsignarCuadrilla(int numeroReclamo)
        {
            LReclamoController reclamoController = new LReclamoController();
            DTO_Reclamo dtoAux = reclamoController.ReclamoByNumero(numeroReclamo);
            int? numeroCuadrilla = reclamoController.FraccionadorDeCuadrillas(dtoAux.numeroZona);
            if (numeroCuadrilla != null)
            {
                reclamoController.ModificarCuadrilla(dtoAux.numero, numeroCuadrilla);
                return RedirectToAction("Listar");
            }
            else
            {
                ModelState.AddModelError("MsgReport", "La zona no tiene cuadrillas asignadas");
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
                return View("Listar", colDataModel);
            }
        }
    }
}