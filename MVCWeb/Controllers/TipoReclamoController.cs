using BussinesLogic.Controllers;
using BussinesLogic.Logic;
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
    public class TipoReclamoController : Controller
    {
        public ActionResult Listar()
        {
            LReclamoController tipoReclamoController = new LReclamoController();
            List<DTO_TipoReclamo> colDataModel = tipoReclamoController.ListarTipoReclamo();

            return View(colDataModel);
        }
        public ActionResult Agregar()
        {
            return View();
        }
        public ActionResult Borrar(int id)
        {
            LReclamoController tipoReclamoController = new LReclamoController();
            DTO_TipoReclamo dto = tipoReclamoController.tipoReclamoById(id);
            return View(dto);
        }
        public ActionResult Editar(int id)
        {
            LReclamoController tipoReclamoController = new LReclamoController();
            DTO_TipoReclamo dto = tipoReclamoController.tipoReclamoById(id);

            return View(dto);
        }
        public ActionResult BorrarTipoReclamo(int id)
        {
            LReclamoController tipoReclamoController = new LReclamoController();
            DTO_TipoReclamo dto = tipoReclamoController.tipoReclamoById(id);
            if (tipoReclamoController.ContieneReclamos(dto))
            {
                ModelState.AddModelError("MsgReport", "El tipo de reclamo tiene reclamos y no puede darse de baja");
                return View("Borrar", dto);
            }
            else
            {
                tipoReclamoController.BorrarTipoReclamo(id);
                return RedirectToAction("Listar");
            }
        }
        public ActionResult AgregarTipoReclamo(DTO_TipoReclamo dto)
        {
            LReclamoController tipoReclamoController = new LReclamoController();
            List<string> colMensajes = tipoReclamoController.AgregarTipoReclamo(dto);

            foreach (string msg in colMensajes)
            {
                ModelState.AddModelError("MsgReport", msg);
            }

            return View("Agregar");
        }
        public ActionResult EditarTipoReclamo(DTO_TipoReclamo dto, int id)
        {
            dto.id = id;
            LReclamoController tipoReclamoController = new LReclamoController();
            tipoReclamoController.ModificarTipoReclamo(dto);

            return RedirectToAction("Listar");
        }
    }
}