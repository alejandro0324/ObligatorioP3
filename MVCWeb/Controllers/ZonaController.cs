using BussinesLogic.Controllers;
using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.Controllers
{
    public class ZonaController : Controller
    {
        public ActionResult Listar()
        {
            LZonaController zonaController = new LZonaController();
            List<DTO_Zona> colDataModel = zonaController.ListarZonas();

            return View(colDataModel);
        }
        public ActionResult Agregar()
        {
            return View();
        }
        public ActionResult Borrar(int numero)
        {
            LZonaController zonaController = new LZonaController();
            DTO_Zona dto = zonaController.ZonaByNumero(numero);
            return View(dto);
        }
        public ActionResult Previsualizar(int numero)
        {
            LZonaController zonaController = new LZonaController();
            DTO_Zona dto = zonaController.ZonaByNumero(numero);
            return View(dto);
        }
        public ActionResult PrevisualizarTodo()
        {
            LZonaController zonaController = new LZonaController();
            List<DTO_Zona> colDataModel = zonaController.ListarZonas();

            return View(colDataModel);
        }
        public ActionResult BorrarZona(int numero)
        {
            LZonaController zonaController = new LZonaController();
            DTO_Zona dto = zonaController.ZonaByNumero(numero);

            if (zonaController.ContieneReclamos(dto))
            {
                ModelState.AddModelError("MsgReport", "La zona contiene reclamos actualmente y no puede ser dada de baja");
                return View("Borrar", dto);
            }
            else
            {
                zonaController.BorrarZona(numero);
                return RedirectToAction("Listar");
            }
        }
        [HttpPost]
        public JsonResult AgregarZona(List<string> puntosGps, string color, string nombre, string numero)
        {
            LZonaController zonaController = new LZonaController();
            List<string> colMensajesLista = zonaController.AgregarZona(puntosGps, color, nombre, numero);
            
            return Json(colMensajesLista, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ValidarNumero(int numero)
        {
            bool rest = true;
            LZonaController zonaController = new LZonaController();
            if (zonaController.ExisteZona(numero) == true)
            {
                rest = false;
            }
            return Json(rest, JsonRequestBehavior.AllowGet);
        }
    }
}