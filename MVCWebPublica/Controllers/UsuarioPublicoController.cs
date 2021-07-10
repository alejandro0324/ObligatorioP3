using BussinesLogic.Logic;
using CommonSolution.Constantes;
using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebPublica.Helpers;

namespace WebPublica.Controllers
{
    public class UsuarioPublicoController : Controller
    {
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return Redirect("~/HomePublica");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(DTO_Usuario dto)
        {
            LUsuarioController controller = new LUsuarioController();
            if (controller.ValidarUsuarioPublico(dto))
            {
                FormsAuthentication.SetAuthCookie(dto.nombreUsuario, false);
                ViewBag.mensaje = " ";

                Session["nombreUsuario"] = dto.nombreUsuario;
                Session["correo"] = controller.GetCorreoByUsuario(dto.nombreUsuario);
                return Redirect("~/HomePublica");
            }
            else
            {
                ViewBag.mensaje = "Usuario o contrseña no válido.";
            }
            return View();
        }

        public ActionResult Registrar()
        {
            ViewBag.errores = "";
            return View();
        }

        public ActionResult RegistrarSubmit(DTO_Usuario dto)
        {
            LUsuarioController controller = new LUsuarioController();

            List<string> errores = controller.RegistrarUsuario(dto, "1");
            if (errores.Count() == 0)
            {
                ViewBag.errores = errores;
                return View("Login");
            }
            else
            {
                ViewBag.errores = errores.FirstOrDefault();
                return View("Registrar");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}