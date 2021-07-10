using BussinesLogic.Controllers;
using CommonSolution.DTOs;
using WebInterna.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebInterna.Controllers
{
    [UserAuthentication]
    public class CuadrillaController : Controller
    {
        public ActionResult Listar()
        {
            LCuadrillaController cuadrillaController = new LCuadrillaController();
            LZonaController zonaController = new LZonaController();
            List<DTO_Cuadrilla> colDataModel = cuadrillaController.ListarCuadrillas();
            foreach (var item in colDataModel)
            {
                item.DTO_Zona = zonaController.ZonaByNumero(item.numZona); 
            }
            return View(colDataModel);
        }
        public ActionResult Agregar()
        {
            LZonaController zonaController = new LZonaController();
            ViewBag.zonas = zonaController.ListarZonas().ToList();
            return View();
        }
        public ActionResult Borrar(int numero)
        {
            LCuadrillaController cuadrillaController = new LCuadrillaController();
            DTO_Cuadrilla dto = cuadrillaController.CuadrillaByNumero(numero);
            return View(dto);
        }
        public ActionResult Editar(int numero)
        {
            LZonaController zonaController = new LZonaController();
            ViewBag.zonas = zonaController.ListarZonas().ToList();
            LCuadrillaController cuadrillaController = new LCuadrillaController();
            DTO_Cuadrilla dto = cuadrillaController.CuadrillaByNumero(numero);

            return View(dto);
        }
        public ActionResult CambiarEstado(int numero)
        {
            LCuadrillaController cuadrillaController = new LCuadrillaController();
            DTO_Cuadrilla dto = cuadrillaController.CuadrillaByNumero(numero);

            if (cuadrillaController.ContieneReclamos(dto))
            {
                ModelState.AddModelError("MsgReport", "La cuadrilla contiene reclamos actualmente y no puede cambiar de estado");
                return View("Borrar", dto);
            }
            else
            {
                if (dto.situacion == "1")
                {
                    cuadrillaController.BorrarCuadrilla(numero);
                }
                else
                {
                    cuadrillaController.ActivarCuadrilla(numero);
                }

                return RedirectToAction("Listar");
            }
        }
        public ActionResult AgregarCuadrilla(DTO_Cuadrilla dto)
        {
            LCuadrillaController cuadrillaController = new LCuadrillaController();  
            List<string> colMensajes = cuadrillaController.AgregarCuadrilla(dto);

            foreach (string msg in colMensajes)
            {
                ModelState.AddModelError("MsgReport", msg);
            }

            LZonaController zonaController = new LZonaController();
            ViewBag.zonas = zonaController.ListarZonas().ToList();

            return View("Agregar");
        }
        public ActionResult EditarCuadrilla(DTO_Cuadrilla dto, int numero)
        {
            LZonaController zonaController = new LZonaController();
            ViewBag.zonas = zonaController.ListarZonas().ToList();
            dto.numero = numero;
            LCuadrillaController cuadrillaController = new LCuadrillaController();
            cuadrillaController.ModificarCuadrilla(dto);

            return RedirectToAction("Listar");
        }
        public JsonResult ValidarNumero(int numero)
        {
            bool rest = true;
            LCuadrillaController cuadrillaController = new LCuadrillaController();
            if (cuadrillaController.ExisteCuadrilla(numero) == true)
            {
                rest = false;
            }
            return Json(rest, JsonRequestBehavior.AllowGet); 
        }
    }
}