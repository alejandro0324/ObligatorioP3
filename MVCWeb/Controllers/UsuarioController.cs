using BussinesLogic.Logic;
using CommonSolution.Constantes;
using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCWeb.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return Redirect("~/Home");
            }
            return View();
        }
        public JsonResult ValidarNombreUsuario(string nombreUsuario)
        {
            bool rest = true;
            LUsuarioController controller = new LUsuarioController();
            if (controller.ExisteNombreUsuario(nombreUsuario))
            {
                rest = false;
            }
            return Json(rest, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Login(DTO_Usuario dto)
        {
            LUsuarioController controller = new LUsuarioController();
            if (controller.ValidarUsuario(dto))
            {
                FormsAuthentication.SetAuthCookie(dto.nombreUsuario, false);
                ViewBag.mensaje = " ";

                return Redirect("~/Home");
            }
            else
            {
                ViewBag.mensaje = "Usuario o contrseña no válido.";
            }
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

        public ActionResult RegistrarSubmit(DTO_Usuario dto)
        {
            LUsuarioController controller = new LUsuarioController();

            controller.RegistrarUsuario(dto, "0");

            return View("Login");
        }
    }
}