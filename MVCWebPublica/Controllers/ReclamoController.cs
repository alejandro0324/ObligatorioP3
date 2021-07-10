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
    [UserAuthentication]
    public class ReclamoController : Controller
    {
        public ActionResult Agregar()
        {
            LReclamoController controller = new LReclamoController();
            List<DTO_TipoReclamo> lista = controller.ListarTipoReclamo().ToList();
            ViewBag.listaTipoReclamo = lista;
            return View();
        }

        public ActionResult AgregarReclamo(DTO_Reclamo dto)
        {
            LReclamoController reclamoController = new LReclamoController();
            List<string> colMensajes = reclamoController.AgregarReclamo(dto);

            foreach (string msg in colMensajes)
            {
                ModelState.AddModelError("MsgReport", msg);
            }

            List<DTO_TipoReclamo> lista = reclamoController.ListarTipoReclamo().ToList();
            ViewBag.listaTipoReclamo = lista;

            return View("Agregar");
        }
        public ActionResult Listar()
        {
            LReclamoController controller = new LReclamoController();
            List<DTO_Reclamo> lista = controller.ListarReclamosPersonales().ToList();
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