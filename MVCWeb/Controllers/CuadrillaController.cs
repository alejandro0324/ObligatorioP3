using BussinesLogic.Controllers;
using CommonSolution.DTOs;
using MVCWeb.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.Controllers
{
    [UserAuthentication]
    public class CuadrillaController : Controller
    {
        public ActionResult Listar()
        {
            LCuadrillaController cuadrillaController = new LCuadrillaController();
            List<DTO_Cuadrilla> colDataModel = cuadrillaController.ListarCuadrillas();

            return View(colDataModel);
        }
        public ActionResult Agregar()
        {
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
            LCuadrillaController cuadrillaController = new LCuadrillaController();
            DTO_Cuadrilla dto = cuadrillaController.CuadrillaByNumero(numero);

            return View(dto);
        }
        public ActionResult BorrarCuadrilla(int numero)
        {
            LCuadrillaController cuadrillaController = new LCuadrillaController();
            cuadrillaController.BorrarCuadrilla(numero);

            return RedirectToAction("Listar");
        }
        public ActionResult AgregarCuadrilla(DTO_Cuadrilla dto)
        {
            LCuadrillaController cuadrillaController = new LCuadrillaController();
            List<string> colMensajes = cuadrillaController.AgregarCuadrilla(dto);

            foreach (string msg in colMensajes)
            {
                ModelState.AddModelError("MsgReport", msg);
            }

            return View("Agregar");
        }
        public ActionResult EditarCuadrilla(DTO_Cuadrilla dto, int numero)
        {
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