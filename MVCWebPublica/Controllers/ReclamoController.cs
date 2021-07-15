using BussinesLogic.Controllers;
using BussinesLogic.Logic;
using CommonSolution.DTOs;
using WebPublica.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPublica.Helpers;

namespace MVCWebPublica.Controllers
{
    [UserPublicoAuthentication]
    public class ReclamoController : Controller
    {
        public ActionResult Agregar()
        {
            LReclamoController controller = new LReclamoController();
            List<DTO_TipoReclamo> lista = controller.ListarTipoReclamo().ToList();
            ViewBag.listaTipoReclamo = lista;
            LZonaController zonaController = new LZonaController();
            ViewBag.Lista = zonaController.ListarZonasActivas();
            return View();
        }

        public JsonResult AgregarReclamo(string tipoReclamo, string observaciones, string latitud, string longitud, string numeroZona)
        {
            List<string> colMensajes = new List<string>();
            if (numeroZona != "-1")
            {
                LReclamoController reclamoController = new LReclamoController();
                DTO_Reclamo dto = new DTO_Reclamo();
                dto.nombreCliente = Session["nombreUsuario"].ToString();
                dto.idTipoReclamo = int.Parse(tipoReclamo);
                dto.observacionesCiudadano = observaciones;
                dto.latitud = latitud;
                dto.longitud = longitud;
                dto.numeroZona = int.Parse(numeroZona);
                colMensajes = reclamoController.AgregarReclamo(dto);
            }
            else
            {
                colMensajes.Add("El reclamo no está en ninguna zona habilitada");
            }
            return Json(colMensajes);
        }
        public ActionResult Listar()
        {
            LReclamoController controller = new LReclamoController();
            string nombreUsuario = Session["nombreUsuario"].ToString();
            List<DTO_Reclamo> lista = controller.ListarReclamosPersonales(nombreUsuario).ToList();
            lista = lista.OrderByDescending(s => s.fchaHora).ToList();
            return View(lista);
        }
        public ActionResult Borrar(int numero)
        {
            LReclamoController reclamoController = new LReclamoController();
            DTO_Reclamo dto = reclamoController.ReclamoByNumero(numero);
            return View(dto);
        }
        public ActionResult BorrarReclamo(int numero)
        {
            LReclamoController reclamoController = new LReclamoController();
            reclamoController.BorrarReclamo(numero);
            return RedirectToAction("Listar");
        }

        public ActionResult Detalles(int numero)
        {
            LLogReclamoController logReclamoController = new LLogReclamoController();
            List<DTO_LogReclamo> dto = logReclamoController.GetLogReclamosByNum(numero);
            return View(dto);
        }
    }
}